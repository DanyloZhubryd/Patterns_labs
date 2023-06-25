import json
import redis
import requests
from datetime import datetime
from abc import abstractmethod
from time import sleep
from typing import List


class DataOutputStrategy:
    @staticmethod
    @abstractmethod
    def output(data):
        pass


class ConsoleStrategy(DataOutputStrategy):
    @staticmethod
    def output(data):
        for key in data[0].keys():
            print(key, end=', ')
        print()
        for row in data:
            for value in row.values():
                print(value, end=', ')
            print()
            sleep(0.1)


class RedisStrategy(DataOutputStrategy):
    @classmethod
    def output(cls, data):
        r = redis.Redis(host='localhost', port=6379, db=0)
        print('Connected to Redis at localhost:6379')

        for d in data:
            key = f"{datetime.now().timestamp()}:{':'.join(str(v) for v in d.values())}"
            r.hset(key, key, json.dumps(d))

        redis_data = []
        for key in r.keys():
            for value in r.hgetall(key).values():
                redis_data.append(
                    {key.decode("utf-8"): json.loads(value.decode("utf-8"))})

        with open('redis_output.json', 'w') as f:
            json.dump(redis_data, f)

        print("Data successfully saved in Redis")


class APIReader:
    @staticmethod
    def load_data_to_json(url, file_name):
        response = requests.get(url)

        if response.status_code == 200:
            data = response.json()
            with open(file_name, 'w') as f:
                json.dump(data, f)
                print(f'Data successfully loaded to {file_name}')
        else:
            raise RuntimeError(
                f'Error: failed to load data from API: {response.status_code}')


class JsonReader:
    @staticmethod
    def json_to_dict(json_file_path):
        with open(json_file_path, 'rb') as json_file:
            return json.loads(json_file.read())


class ConfigReader:
    @staticmethod
    def read_config(config_file_path):
        config = JsonReader.json_to_dict(config_file_path)
        if config['strategy'] == 'console':
            config['strategy'] = ConsoleStrategy
        elif config['strategy'] == 'redis':
            config['strategy'] = RedisStrategy
        else:
            raise ValueError('Error: Wrong strategy name in config')
        return config


class OutputContext:
    def __init__(self, json_file_path: str, strategy: DataOutputStrategy = ConsoleStrategy):
        self.dataset: List[dict] = JsonReader.json_to_dict(json_file_path)
        self.strategy = strategy

    def output_data(self):
        self.strategy.output(self.dataset)


if __name__ == '__main__':
    config = ConfigReader.read_config('config.json')
    APIReader.load_data_to_json(config['data_url'],
                                config['json_file_path'])
    data_context = OutputContext(json_file_path=config['json_file_path'],
                                 strategy=config['strategy'])
    data_context.output_data()
