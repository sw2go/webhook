Projekt um Post Requests zu analysieren
---------------------------------------

Ein Aufruf auf https://yourhost/buffer zeigt immer den Inhalt des letzten POST Request, 
wobei die Body-Bytes des Request als utf8 oder base64 ausgegeben werden 

Webhooks posten auf:

https://yourhost/buffer/utf8       
https://yourhost/buffer/base64


AResponseHandler, Hello und Text werden nicht vom Buffer-Controller benötigt 
Diese Klassen sind Beispiele für Webhook Implementationen mit 
einem Post-Request Objekt und einem Response Objekt


Inspiriert von: 
https://khalidabuhakmeh.com/implement-a-webhook-framework-with-aspnetcore
https://weblog.west-wind.com/posts/2017/sep/14/accepting-raw-request-body-content-in-aspnet-core-api-controllers

Zum probieren:

Postman Request:
POST https://localhost:44305/wh/Hello
Body: raw JSON(application/json)
{
  "Name": "Hans"
}

Response:
{
    "greeting": "Hello, Hans"
}


POST https://localhost:44305/raw/json