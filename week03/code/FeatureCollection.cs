public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    /*
    {
        "type": "Feature",
        "properties": {
            "mag": 2,
            "place": "15 km W of Point Possession, Alaska",
            "time": 1763070841343,
            "updated": 1763070990911,
            "tz": null,
            "url": "https://earthquake.usgs.gov/earthquakes/eventpage/ak025ekm6ozc",
            "detail": "https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/ak025ekm6ozc.geojson",
            "felt": null,
            "cdi": null,
            "mmi": null,
            "alert": null,
            "status": "automatic",
            "tsunami": 0,
            "sig": 62,
            "net": "ak",
            "code": "025ekm6ozc",
            "ids": ",ak025ekm6ozc,",
            "sources": ",ak,",
            "types": ",origin,phase-data,",
            "nst": null,
            "dmin": null,
            "rms": 0.78,
            "gap": null,
            "magType": "ml",
            "type": "earthquake",
            "title": "M 2.0 - 15 km W of Point Possession, Alaska"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [
                -150.9812,
                60.9362,
                33.3
            ]
        },
        "id": "ak025ekm6ozc"
    },
    */

    public string type { get; set; }
    public Metadata metadata { get; set; }
    public Feature[] features { get; set; }

    // Metadata
    public class Metadata
    {
        public long generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string api { get; set; }
        public int count { get; set; }
    }

    // Feature
    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
        public string id { get; set; }
    }

    // Properties
    public class Properties
    {
        public double? mag { get; set; }
        public string place { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public int? tz { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
        public int? felt { get; set; }
        public double? cdi { get; set; }
        public double? mmi { get; set; }
        public string alert { get; set; }
        public string status { get; set; }
        public int tsunami { get; set; }
        public int sig { get; set; }
        public string net { get; set; }
        public string code { get; set; }
        public string ids { get; set; }
        public string sources { get; set; }
        public string types { get; set; }
        public int? nst { get; set; }
        public double? dmin { get; set; }
        public double? rms { get; set; }
        public double? gap { get; set; }
        public string magType { get; set; }
        public string type { get; set; }
        public string title { get; set; }
    }

    // Geometry
    public class Geometry
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }
}