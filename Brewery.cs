using System;
using System.Text.Json.Serialization;

namespace ApiClient
{
    public class Brewery
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("brewery_type")]
        public string BreweryType { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("county_province")]
        public string County { get; set; }
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("website_url")]
        public string Website { get; set; }
    }
}

// //  "id": "10-barrel-brewing-co-san-diego",
//     "name": "10 Barrel Brewing Co",
//     "brewery_type": "large",
//     "street": "1501 E St",
//     "address_2": null,
//     "address_3": null,
//     "city": "San Diego",
//     "state": "California",
//     "county_province": null,
//     "postal_code": "92101-6618",
//     "country": "United States",
//     "longitude": "-117.129593",
//     "latitude": "32.714813",
//     "phone": "6195782311",
//     "website_url": "http://10barrel.com",
//     "updated_at": "2021-10-23T02:24:55.243Z",
//     "created_at": "2021-10-23T02:24:55.243Z