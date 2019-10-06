

## Test

```powershell
Clear-Host

$base = "http://localhost:49940/";
$messageId = "A29E9D0C-7169-48ED-951F-7A2C94E68802";
$encoding = "UTF-16";
$url = "$base/Messages/GetMessage/$messageId/$encoding";



$response = Invoke-WebRequest -Method Get -Uri $url;
$response.Content;

```