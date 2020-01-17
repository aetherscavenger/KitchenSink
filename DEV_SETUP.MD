# Synopsis
If you need to debug SSL, CORS, DNS you can set up the IIS method.

# IIS MVC
- In IIS Manager create a new site called KitchenSinkMVC
- Set it's Physical path to the root project folder for KitchenSinkMVC
- Set the Host Name to mvc.sink.local
- As Administrator add the entry `127.0.0.0 mvc.sink.local` to the file C:\Windows\System32\drivers\etc\hosts

# Project MVC
- Right click the project and click "Properties"
- In the left hand pane click "Debug"
- Switch the "Profile" to "KitchenSinkMVC"
- In "App URL" put http://mvc.sink.local