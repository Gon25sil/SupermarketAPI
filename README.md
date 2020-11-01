# Supermarket Restuful Web Api
## Geting Started
### How to start the api and database server
This will run the api at http://localhost:8080/
```
docker-compose up --build
```
## Using Swagger

This Api uses the "Swagger" tool to better describe its structure. Access  http://localhost:8080/swagger for a better user experience.
# API overview

The following section provides a high level description of the API.

## Application endpoints

### Products controller endpoints
||***Path***|***Method***|***Description***|***Status Code***|
|--|--|--|--|--|
|1|/api/Products|GET|Returns all the Products in the database|200|
|2|/api​/Products​/id|GET|Returns the Productwith the specified id|200, 404|
|3|​/api​/Products|POST|Creates a new Product|201, 400|
|4|​/api​/Products​/id|PUT|Updates the Product with the specified id|200, 400|
|5|​/api​/Products​/id|DELETE|Deletes the Product with the specified id|200, 400|
### Categories controller endpoints
||***Path***|***Method***|***Description***|***Status Code***|
|--|--|--|--|--|
|1|/api/Categories|GET|Returns all the Categories in the database|200|
|2|/api​/Categories/id|GET|Returns the Category with the specified id|200, 404|
|3|​/api​/Categories|POST|Creates a new Category|201, 400|
|4|​/api​/Categories​/id|PUT|Updates the Category with the specified id|200, 400|
|5|​/api​/Categories/id|DELETE|Deletes the Category with the specified id|200, 400|
### Return Codes
| ***Code*** | ***Description*** |
|------|-------------|
| 200  | Success     |
| 201  | Created     |
| 400  | Bad Request |
| 404  | Not Found   |



