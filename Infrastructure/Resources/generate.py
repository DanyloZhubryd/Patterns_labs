import csv
import random
import faker as faker
from pathlib import Path

path = Path(__file__).parent / 'Generated/'


def generate_user_csv():
    fake = faker.Faker()
    users = []
    for i in range(1000):
        name = fake.text(max_nb_chars=50)[:-1]
        user = {'Username': name}
        users.append(user)

    with open(path / 'user.csv', mode='w', newline='') as file:
        fieldnames = ['Username']
        writer = csv.DictWriter(file, fieldnames=fieldnames)
        writer.writeheader()
        for user in users:
            writer.writerow(user)


def generate_story_csv():
    fake = faker.Faker()
    media_urls = ["media/image1.png", "media/image2.png",
                  "media/image2.png", "media/image2.png"]
    stories = []
    for i in range(1000):
        caption = fake.text(max_nb_chars=150)[:-1]
        media_url = random.choice(media_urls)
        user_id = random.randint(5, 1000)
        is_close_friends_only = bool(random.getrandbits(1))
        story = {'Caption': caption, 'MediaUrl': media_url,
                 'IsCloseFriendsOnly': is_close_friends_only, 'UserId': user_id}
        stories.append(story)

    with open(path / 'story.csv', mode='w', newline='') as file:
        fieldnames = ['Caption', 'MediaUrl', 'IsCloseFriendsOnly', 'UserId']
        writer = csv.DictWriter(file, fieldnames=fieldnames)
        writer.writeheader()
        for story in stories:
            writer.writerow(story)


def generate_comment_csv():
    fake = faker.Faker()
    comments = []
    for i in range(1000):
        text = fake.text(max_nb_chars=450)[:-1]
        user_id = random.randint(5, 1000)
        story_id = random.randint(5, 1000)
        comment = {'Text': text, 'UserId': user_id, 'StoryId': story_id}
        comments.append(comment)

    with open(path / 'comment.csv', mode='w', newline='') as file:
        fieldnames = ['Text', 'UserId', 'StoryId']
        writer = csv.DictWriter(file, fieldnames=fieldnames)
        writer.writeheader()
        for comment in comments:
            writer.writerow(comment)


def generate_reaction_csv():
    fake = faker.Faker()
    reactions = []
    for i in range(1000):
        type = random.randint(1, 6)
        user_id = random.randint(5, 1000)
        story_id = random.randint(5, 1000)
        reaction = {"Type": type,
                    'UserId': user_id, 'StoryId': story_id}
        reactions.append(reaction)

    with open(path / 'reaction.csv', mode='w', newline='') as file:
        fieldnames = ['Type', 'UserId', 'StoryId']
        writer = csv.DictWriter(file, fieldnames=fieldnames)
        writer.writeheader()
        for reaction in reactions:
            writer.writerow(reaction)


if __name__ == '__main__':
    generate_user_csv()
    generate_story_csv()
    generate_comment_csv()
    generate_reaction_csv()
