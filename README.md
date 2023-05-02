# Lab2
## Task
Implement the server part of the application, which consists of three levels:
- Data access level
- Level of business logic
- Presentation level

  Communication between layers should be implemented using interfaces (classes of the business logic layer should use interfaces of the data access layer, not implementation) and patterns of inversion of control and implementation of dependencies.
  The presentation layer currently does not perform any logic and is represented only by interfaces
  The data access level should be implemented using the ORM framework to populate the database created in laboratory 1.b (class diagram). Also, at the data access level, data reading from a .csv file should be implemented.
  The business logic layer calls the data access layer to read data from the file, creates the necessary models to populate the database, and calls the data access layer to store the information in the database.

  __Important__: all data must be contained in one file. When loading data into the database, you should implement the necessary logic to correctly save the data in the table.
The file must contain a minimum of 1000 lines.
To create a file, you should create a separate module/class that is run from the command line.
## Class diagram
You can check out UML class diagram for this project [here](https://drive.google.com/file/d/1vNvF1DDgERuoMHlZ3B40x5hPBZPuDwUX/view?usp=sharing)
