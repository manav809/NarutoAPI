# Naruto API: The API Hidden in the Leaf
### Manav Minesh Patel


##### HTTP Endpoints

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

#### DELETE Requests:

```bash
DELETE/api/character/${id}
```




