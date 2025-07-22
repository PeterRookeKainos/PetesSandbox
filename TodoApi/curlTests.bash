#!/bin/bash

export NORMAL="[0m"
export BOLD_ON="[1m"
        
export HOST=https://localhost:7198

#WeatherForecast API
#curl -k ${HOST}/weatherforecast
#curl -k ${HOST}/weatherforecast/1

#OpenAPI Swagger ??? - not working?
#curl -k ${HOST}/swagger/index.html
#curl -k ${HOST}/swagger/v1/swagger.json
#curl -k ${HOST}/swagger/v1/swagger.json -o swagger.json 

echo "${BOLD_ON}POST /api/TodoItems {"name": "walk dog", "isComplete": true} ${NORMAL}"
# create a curl command to POST to /api/TodoItems the values {"name": "walk dog", "isComplete": true}
curl -k -X POST ${HOST}/api/TodoItems -H "Content-Type: application/json" -d '{"name": "walk dog", "isComplete": true}'

echo "${BOLD_ON}/api/TodoItems${NORMAL}"
# create a curl command to GET /api/TodoItems
curl -k ${HOST}/api/TodoItems | jq '.[] | {id, name, isComplete}'

echo "${BOLD_ON} /api/TodoItems/1 {"name": "feed fish", "isComplete": false} ${NORMAL}"
# create a curl command to PUT to /api/TodoItems/1 the values {"name": "feed fish", "isComplete": false}
curl -k -X PUT ${HOST}/api/TodoItems/1 -H "Content-Type: application/json" -d '{"id":"1", "name": "feed fish", "isComplete": false}'

echo "${BOLD_ON}GET /api/TodoItems${NORMAL}"
# create a curl command to GET /api/TodoItems
curl -k ${HOST}/api/TodoItems | jq '.[] | {id, name, isComplete}'

echo "${BOLD_ON}DELETE /api/TodoItems/1${NORMAL}"
# create a curl command to DELETE /api/TodoItems/1
curl -k -X DELETE ${HOST}/api/TodoItems/1

echo "${BOLD_ON}GET /api/TodoItems${NORMAL}"
# create a curl command to GET /api/TodoItems
curl -k ${HOST}/api/TodoItems | jq '.[] | {id, name, isComplete}'

                                                              
