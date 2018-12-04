function initMap() {

    let map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: { lat: 42.650815, lng: 23.379388 }
    });

    let allLocations = document.getElementsByClassName('sensor-location');

    let locations = [];

    for (loc of allLocations) {
        locations.push({
            lat: parseFloat(loc.getElementsByClassName('sensor-lat')[0].textContent),
            lng: parseFloat(loc.getElementsByClassName('sensor-lng')[0].textContent)
        });
    }
         
    let labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

    let markers = locations.map(function (location, i) {
        return new google.maps.Marker({
            position: location,
            label: labels[i % labels.length]
        });
    });

    let markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' }
    );
}