##webhook (webhook analyzer utility)

asp.net core project to show the content of the last post-request

let your webhook post to  ... /buffer/utf-8
and view the request here ... /buffer

to use other formats just change last segment in the post url: i.e. for base64 -> /buffer/base64 

Inspired by: https://weblog.west-wind.com/posts/2017/sep/14/accepting-raw-request-body-content-in-aspnet-core-api-controllers


##webhook sample

asp.net core "hello" webhook handler based on generic AResponseHandler

post { "Name": "YourName" } with Content-Type: "application/json" to ... /wh/hello

Inspired by: https://khalidabuhakmeh.com/implement-a-webhook-framework-with-aspnetcore
