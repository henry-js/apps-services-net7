# 1..8 | ForEach-Object {
#     Invoke-WebRequest -Uri "https://raw.githubusercontent.com/markjprice/apps-services-net7/main/images/Categories/category$_.jpeg" -OutFile ".\category$_.jpeg"
# }

Invoke-WebRequest -Uri "https://raw.githubusercontent.com/markjprice/apps-services-net7/main/images/Categories/categories.jpeg" -OutFile ".\App\Images\categories.jpeg"
