import 'ol/ol.css';
import Feature from 'ol/Feature';
import Map from 'ol/Map';
import Polyline from 'ol/format/Polyline';
import OSM from 'ol/source/OSM.js';
import VectorSource from 'ol/source/Vector';
import View from 'ol/View';
import { Stroke, Style } from 'ol/style';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer';

const map = new Map({
    layers: [
        new TileLayer({
            source: new OSM(),
        }),
    ],
    target: 'map',
    view: new View({
        center: [0, 0],
        zoom: 2,
    }),
});

const coordinates = [
    [-1.486821, 52.926413],
    [-1.495123, 52.925369],
];

fetch(
    'https://router.project-osrm.org/route/v1/driving/' +
    coordinates.join(';') +
    '?overview=full&geometries=polyline6'
).then(function (response) {
    response.json().then(function (result) {
        const polyline = result.routes[0].geometry;

        const route = new Polyline({
            factor: 1e6,
        }).readGeometry(polyline, {
            dataProjection: 'EPSG:4326',
            featureProjection: map.getView().getProjection(),
        });
        const routeFeature = new Feature({
            type: 'route',
            geometry: route,
        });

        const vectorLayer = new VectorLayer({
            source: new VectorSource({
                features: [routeFeature],
            }),
            style: new Style({
                stroke: new Stroke({
                    width: 4,
                    color: 'red',
                }),
            }),
        });

        map.addLayer(vectorLayer);
        map.getView().fit(routeFeature.getGeometry());
    });
});
