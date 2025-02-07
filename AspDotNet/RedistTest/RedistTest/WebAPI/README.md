
# Install Redis server
* -> https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504

# Install NuGet packages
* -> Microsoft.EntityFrameworkCore
* -> Microsoft.EntityFrameworkCore.Design
* -> Microsoft.EntityFrameworkCore.SqlServer
* -> Microsoft.EntityFrameworkCore.Tools
* -> Swashbuckle.AspNetCore
* -> StackExchange.Redis

# Implement
* -> nói chung về cơ bản thì ta sẽ check xem có trong cache chưa, chưa có thì vô "database" lấy đồng thời intiate cache cho nó

* sẽ có trường hợp ta cần take care of using caching:
* -> When the first user sends the request to fetch the data of all products, the first request comes, and then it will check if the data is present inside the cache or not. If the data is present inside the cache, then it will fetch the data from the database and also set it to the cache.
* -> Meanwhile, the Second User sends the request to get the product details. What happened is that the request also hits the database before completing the first user’s request, and because of that second user also hits the database to fetch product details.

* => so there is one solution for this to use the **`Lock Mechanism`** 

## Lock
* -> first, we check if the data is present inside the cache or not; if data is available, then return that
* -> if the value is not present in the Redis cache, then we apply the lock over there
* -> and then the request is locked and entered into the section fetches the product details from the database and then also sets it to the cache and returns the data
* -> in that case the second user sends a request before the user’s request is complete, the second request is in the queue, 
* -> and after completing the first user request, the second request comes into the picture