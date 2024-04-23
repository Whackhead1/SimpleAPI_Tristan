## Creating and Running the PostgreSQL Database

1. Ensure you have the `docker-compose.yml` file in your current directory.
2. Run the following command in your terminal:

    ```bash
    docker-compose up -d
    ```

   This command will create and start the PostgreSQL database container in detached mode.

The database is now running on `localhost:5432`.

## Accessing the Database with Adminer

If you wish to view the schema/data in your browser, you can use Adminer:

1. Navigate to [localhost:8080](http://localhost:8080).
2. Set **System** to **PostgreSQL**.
3. Set **Server** to **db**. This is because in the `docker-compose.yml`, we gave the database container an identifier, and since Adminer and the database are in the same Docker network, you can refer to the database by its service name.
4. Enter your login details.


### Running EF6 Migrations

1. Navigate to `View -> Other Windows -> Package Manager Console` in Visual Studio.
2. Execute the `update-database` command in the Package Manager Console.

This command will apply any pending migrations to the target database, ensuring that the database schema is up-to-date with the current state of the codebase.


## Testing the ASP.NET API with Postman

You can test your ASP.NET Web API using Postman, a popular tool for API testing.

1. Open Postman on your machine. If you don't have Postman installed, you can download it [here](https://www.postman.com/downloads/).
2. Create a new request by clicking on the "New" button in the upper left corner of the Postman window.
3. Choose the appropriate HTTP method (e.g., GET, POST, PUT, DELETE) depending on the endpoint you want to test.
4. Since the API is running locally on port 52417, the URL will be `http://localhost:52417/`.
5. Edit the URL as needed in order to access the endpoints. E.g. `http://localhost:52417/Applicant/GetAll`
6. Select **Body** and select **raw / JSON** as type.
7. Click the "Send" button to send the request to your ASP.NET API.
8. Review the response from the API in the Postman window.

Here's an example of testing an Update request with a JSON body to `http://localhost:52417/Applicant/update`:

- **Method:** PATCH
- **URL:** `http://localhost:52417/Applicant/update`
- **Body:**
  ```json
  {
    "Id": 4,
    "Name": "TestNameHere"
  }g