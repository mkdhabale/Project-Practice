Use Below Code snippet to Call API to fetch getusers details

There are 2 ways to Execute this [
[A] parameter from Body
[B] parameter from Query string

[A] parameter from Body
1. JavaScript - Fetch
var myHeaders = new Headers();
myHeaders.append("Content-Type", "application/json");

var raw = JSON.stringify({
  "usernames": [
    "pjhyett",
    "mukulk",
    "mojombo1"
  ]
});

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  body: raw,
  redirect: 'follow'
};

fetch("https://localhost:44362/api/Git", requestOptions)
  .then(response => response.text())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));
  


2. C# - RestSharp
var client = new RestClient("https://localhost:44362/api/Git");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("Content-Type", "application/json");
var body = @"{
" + "\n" +
@"    ""usernames"": [""pjhyett"",""mukulk"",""mojombo1""]
" + "\n" +
@"}";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);



3. cURL
curl --location --request GET 'https://localhost:44362/api/Git' \
--header 'Content-Type: application/json' \
--data-raw '{
    "usernames": ["pjhyett","mukulk","mojombo1"]
}'





[B] parameter from Query string
1. JavaScript - Fetch
var requestOptions = {
  method: 'GET',
  redirect: 'follow'
};

fetch("https://localhost:44362/api/Git?usernames=pjhyett&usernames=mukulk&usernames=mojombo1", requestOptions)
  .then(response => response.text())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));


2. C# - RestSharp
var client = new RestClient("https://localhost:44362/api/Git?usernames=pjhyett&usernames=mukulk&usernames=mojombo1");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);


3. cURL
curl --location --request GET 'https://localhost:44362/api/Git?usernames=pjhyett&usernames=mukulk&usernames=mojombo1'






RESPONSE OBJECT 
[
    {
        "name": null,
        "login": "MukulK",
        "company": null,
        "followers": 0,
        "public_repos": 2,
        "avg_no_followers_per_publicrepositories": 0,
        "is_found": true,
        "error": null
    }
]

    * name
    * login
    * company
    * number of followers
    * number of public repositories
    * The average number of followers per public repository
	* found in git repository or not
	* if not found or any error from Git repository then showing that also to user


