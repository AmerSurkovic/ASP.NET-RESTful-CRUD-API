## ASP.NET REST API
Project implements RESTful CRUD web API in C# using ASP.NET for managing a banner model. Data is backed by **MongoDB**. Method providing the HTML stored in the banner is also implemented.

### Packages
* **Controllers**
  
  [BannerController](BannerFlow/Controllers/BannerController.cs)
* **Services**

  [IBannerService](BannerFlow/Services/IBannerService.cs)
  
  [BannerService](BannerFlow/Services/BannerService.cs)
* **Repositories**

  [IBannerRepository](BannerFlow/Repositories/IBannerRepository.cs)
  
  [BannerRepository](BannerFlow/Repositories/BannerRepository.cs)
* **Models**

  [Banner](BannerFlow/Models/Banner.cs)
* **DataTransferObjects**
  
  [BannerDTO](BannerFlow/DataTransferObjects/BannerDTO.cs)
* **Validators**

  [HtmlValidator](BannerFlow/Validators/HtmlValidator.cs)

### API Calls
* **GET api/banners**

  Returns all banners from the database.
* **GET api/banners/{id}**

  Returns the banner from the database for a specified ID.
* **POST api/banners**

  Creates a banner record in the database.
* **PUT api/banners/{id}**

  Updates the banner record in the database for a specified ID with sent update data.
* **DELETE api/banners/{id}**

  Removes the banner record from the database for a specified ID.
* **GET api/banners/{id}/html**

  Provides the HTML stored in the banner. Renders correctly in a modern browser - HTML load available in the [developed client](BannerFlow/Index.html).

### Testing the API
Testing was done using both: 
* [Postman](Postman%20API%20testing)

  Used for testing all of the API calls. Provides a better insight to illegal calls and for observing error handling.
* [Developed client](BannerFlow/Index.html)

  Also used for testing of the API calls but with focus on proper loading of HTML into the modern web browser.

 ### Postman API Test Results
* **GET ALL /api/banners with an empty database**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetAll_EmptyDB.png)
 
* **GET ALL /api/banners with a populated database**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetAll_SeededDB.png)
 
* **POST BANNER /api/banners : Status code 200**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Post_200.png)
 
* **POST BANNER /api/banners : Status code 500**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Post_500.png)
 
* **POST BANNER NOT VALID HTML /api/banners : Status code 500**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/NonValidHTML.png)
 
* **GET BANNER /api/banners/1 : Status code 200**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetBanner_200.png)
 
* **GET BANNER /api/banners : Status code 404**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetBanner_404.png) 
 
* **PUT BANNER /api/banners/1 : Status code 200**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Put_200.png)
 
* **PUT BANNER /api/banners/1 : Status code 500**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Put_500.png) 
 
* **DELETE BANNER /api/banners/2 : Status code 200**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Delete_200.png)
 
* **DELETE BANNER /api/banners/1000 : Status code 500**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/Delete_500.png) 

* **GET BANNER HTML /api/banners/1/html : Status code 200**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetHtml_200.png)
 
* **GET BANNER HTML /api/banners/1000/html : Status code 404**
 ![alt text](Postman%20API%20testing/Test%20calls%20screenshots/GetHtml_404.png) 

## Testing with the client
Developed client uses all of the CRUD API calls including **HTML loading for a given banner**. Since the CRUD API calls are tested and presented using Postman they will be not be shown again on the client side. **More important aspect is tested through client - and that is correct rendering of HTML when called through the API for the specified bannner.**

* **Client side overview**

  ![alt text](Client%20API%20tests/Application.png)
  
* **Load HTML 1**

  ![alt text](Client%20API%20tests/LoadHtml1.png)
  
* **Load HTML 2**

  ![alt text](Client%20API%20tests/LoadHtml2.png)
  
* **Load HTML 3**

  ![alt text](Client%20API%20tests/LoadHtml3.png)
  
* **Load HTML 4**

  ![alt text](Client%20API%20tests/LoadHtml4.png)
