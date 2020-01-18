# DEV
## API Postman instructions
- API URL: https://localhost:44343/
- Authorization: Basic
  - User: qw_1121
  - Password: password

End points:
- [GET] https://localhost:44343/api/customer?id={optional}
  - Returns an array of customer objects, if an id is supplied in the query string it will return a single item array with that customer if it finds it.

Sample:
```json 
[
    {
        "_id": 1234567,
        "address": [
            {
                "key": 0,
                "value": {
                    "addressLine1": "997 Melrose Street, Chaparrito, Washington, 1367",
                    "addressLine2": null,
                    "city": null,
                    "country": null,
                    "postalCode": null,
                    "stateProvince": null
                }
            }
        ],
        "agent": {
            "_id": 0,
            "address": null,
            "displayName": null,
            "phones": null,
            "tier": 0
        },
        "balance": 13612.71,
        "birthDate": null,
        "characteristics": [
            {
                "key": "Age",
                "value": "77"
            },
            {
                "key": "EyeColor",
                "value": "blue"
            }
        ],
        "emails": [
            {
                "value": "buchanan.barr@zappix.net",
                "encryptedPayload": null,
                "type": 0
            }
        ],
        "encryptedPayload": null,
        "firstName": "Buchanan",
        "guid": "f5c1ffed-fd1a-450f-94a8-f2d0842de50c",
        "isActive": false,
        "lastMobileLocation": {
            "latitude": 58.098824,
            "longitude": 130.81152
        },
        "lastName": "Barr",
        "middleName": null,
        "phones": [
            {
                "canSms": false,
                "extension": null,
                "number": "+1 (932) 473-3214",
                "optInSms": false,
                "type": 0
            }
        ],
        "preferredName": null,
        "tags": [
            "ad",
            "laboris",
            "consectetur",
            "nulla",
            "nulla"
        ]
    }
]
```
- [POST] https://localhost:44343/api/customer
  - Inserts/updates a customer record using a customer object (see sample in GET)
- [DELETE] https://localhost:44343/api/customer?id={required}
  - Deletes a customer record using the id of the customer.

- [GET] https://localhost:44343/api/agent?id={optional}
  - Returns an array of agent objects, if an id is supplied in the query string it will return a single item array with that agent if it finds it.

Sample:
```json
[
    {
        "_id": 101,
        "address": {
            "addressLine1": "123 Main Street #200",
            "addressLine2": null,
            "city": "Seattle",
            "country": null,
            "postalCode": "98101",
            "stateProvince": "WA"
        },
        "displayName": "John Doe",
        "phones": [
            {
                "canSms": false,
                "extension": null,
                "number": "206-221-2345",
                "optInSms": false,
                "type": 0
            },
            {
                "canSms": false,
                "extension": null,
                "number": "206-555-3211",
                "optInSms": false,
                "type": 2
            }
        ],
        "tier": 2
    }
]
```
- [POST] https://localhost:44343/api/agent
  - Inserts/updates an agent record using a agent object (see sample in GET)

- [GET] https://localhost:44343/api/agentCustomer?agentId={required}
  - Returns an array of customer objects based on the agent id supplied in the query string.

# PROD
- The API project should be published to https://api.kitchensink.com
- The MVC project should be published to https://mvc.kitchensink.com