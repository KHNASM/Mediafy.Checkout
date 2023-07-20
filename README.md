Layered Desing:
The application has been split into multiple dotnet assemblies, each of which represents a layer. This is to facilitate any future changes or reuse. For example, in order for the application functionalities to be reused from Android client, all what is needed is to add a thin API (REST, PRC, gRPC or whatever) endpoint layer that can communicate with the existing business layer. Such API layer will be very lean as all it would need to do is to delegate the requests to the business layer. Another example is that since the domain layer is completely unaware of persistence technology, only by replacing/modifying the data access layer the persistence technology can be switched. In summary, application has been split in to loosely coupled layers with clear separation of concerns in mind in order to facilitate any future changes, reusability, maintainability, and growth. 

In-memory data stored replaced with persisted data stored:
So that the data context can be injected into the data consumer components, data store has been changed from in-memory to persisted one in order to remove the limitation of single open connection. This allowed for the dependencies to be injected with a per-request scoped lifetime basis, the very natural choice for the HTTP stateless model. 

Third-party API calls moved from client to the server:
The client-side JavaScript API calls have been moved to the server. The client-side API calls is a bad idea in my opinion for it would reveal the API endpoint to everyone, so:
If the API is an unauthenticated public API, this opens up the opportunities for a malicious user of, for example, denial-of-service attack.
In case of authenticated API, this would reveal the API secrets (security tokens, secret keys or passwords etc).
Although situation is much better compared to the past, vanilla JavaScript can still exhibit browser compatibilities issues on times. 

Configurable API Endpoint:
The third-party API endpoints have been made configurable. This removed the strong dependency on the endpoint URLs. In case an endpoint switches the URI, our application can be reconfigured to work with the new URI without the need for the redeployment.

Configurable Input Validation Rules:
The user input validation rules have been made configurable, so validation rules can be changed without the need for the redeployment.

Configurable Ordering Country to Delivering Country Mapping:
What countries can order what offer has been made configurable, so it can be changed, if needed, without the need for the application redeployment. 

Dependency Injection and Separation of Concern:
Application has been changed to make full use of Dependency Injection. This allowed the neat separation of concern. For example, the data access logic has been completely removed from the presentation layers and now the data access is provided via the dedicated components that can be injected into any consumer. This not only drew neat boundaries between the various concerns but also opened up the opportunity of automated testing.

Magic String:
Loose textual SQL queries have been completely removed and database querying is now done via the ORM (Entity Framework). This reduces chances of bugs, incorporates strong typing which gets better tooling support, increases maintainability and so on.
