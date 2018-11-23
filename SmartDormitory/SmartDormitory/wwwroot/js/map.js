function initMap() {

    let map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: { lat: 42.650815, lng: 23.379388 }
    });

    let locations = [
        { lat: 42.658442, lng: 23.362691 },
        { lat: 42.665868, lng: 23.393298 },
        { lat: 42.712275, lng: 23.404959 },
        { lat: -33.848588, lng: 151.209834 },
        { lat: -33.851702, lng: 151.216968 },
    ]
     
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