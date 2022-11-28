# Naruto API: The API Hidden in the Leaf
### Manav Minesh Patel


## HTTP Endpoints

#### GET Requests:

```bash
Get all characters: GET/api/character/
Get specific character: GET/api/character/${id}
Get all clan: GET/api/clan/
Get specific clan: GET/api/clan/${id}
```

#### PUT Requests and POST Requests:

```bash
PUT/api/character/
POST/api/character/

Request Body:
{
  "characterId": 0,
  "characterName": "string",
  "gender": "string",
  "clanId": 0,
  "clanName": "string"
}

PUT/api/clan/
POST/api/clan/

Request Body:
{
  "clanId": int,
  "clanName": "string",
  "clanCharacters": [
    {
      "characterId": 0,
      "characterName": "string",
      "gender": "string",
      "clanId": 0,
      "clanName": "string"
    }
  ]
}
** Note: clanCharacters is unnecessary
```

#### DELETE Requests:

```bash
DELETE/api/character/${id}
```

#### Project Requirements and Status Checklist:
- [X] 3 Endpoints
    - [X] api/character/
    - [X] api/character/${id}
    - [X] api/clan/
    - [X] api/clan/${id}
- [X] 3 Methods
    - [X] GET
    - [X] POST
    - [X] PUT
    - [X] DELETE
- [X] 1 Controller
    - [X] Character Controller
    - [X] Clan Controller
- [X] Response Model
    - [X] statusCode
    - [X] statusDescription
- [X] Two Tables
    - [X] Characters
    - [X] Clans
- [X] One Foreign Key
    - [X] ClanID, One to Many from Clans table to Character Table
- [X] Additional Constraint
    - [X] CharacterName not null




