import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { FiPlus, FiArrowRight, FiAlertOctagon } from 'react-icons/fi';
import { Map, TileLayer, Marker, Popup } from 'react-leaflet';

import api from '../services/api';

import mapIcon from '../utils/mapIcon';

import mapMakerImg from '../images/map-marker.svg'

import '../styles/pages/orphanages-map.css';
import { AllOrphanages } from '../types/AllOrphanages';

function OrphanagesMap() {

  const [orphanages, setOrphaanges] = useState<AllOrphanages[]>([]);

  useEffect(() => {
    api.get("/orphanages-map").then(res => {
      setOrphaanges(res.data);
    });
  }, []);

  return (
    <div id="page-map">
      <aside>
        <header>
          <img src={mapMakerImg} alt="Logo da plataforma Happy" />

          <h2>Escolha um orfanato no mapa</h2>
          <p>Muitas crianças estão esperando sua visita :)</p>
        </header>

        <footer>
          <strong>RIO DE JANEIRO</strong>
          <span>Rio de Janeiro</span>
        </footer>

        <Link to="/auth" style={{ textDecoration: 'none' , color: 'red'}}><strong>ADMINISTRADOR </strong>
            <FiAlertOctagon size={32} color="red" style={{marginBottom: '-9px'}}/>
        </Link>
      </aside>

      <Map
        center={[-22.9035, -43.2096]}
        zoom={10}
        style={{ width: "100%", height: "100%" }}
      >

        {/* Mapa alternativo: "https://api.mapbox.com/styles/v1/mapbox/light-v10/tiles/256/{z}/{x}/{y}@2x?access_token=${process.env.REACT_APP_MAPBOX_TOKEN}" */}
        <TileLayer
          url={
            `https://a.tile.openstreetmap.org/{z}/{x}/{y}.png`
          }
        />

        {orphanages.map(orphanage => {
          return (
            <Marker
              key={orphanage.id}
              icon={mapIcon}
              position={[orphanage.latitude, orphanage.longitude]}
            >
              <Popup
                closeButton={false}
                minWidth={240}
                maxWidth={240}
                className="map-popup"
              >
                {orphanage.name}
                <Link to={`/orphanages/${orphanage.id}`}>
                  <FiArrowRight size={20} color="#FFF" />
                </Link>
              </Popup>
            </Marker>
          )
        })}

      </Map>

      <Link to="/orphanages/create" className="create-orphanage">
        <FiPlus size={32} color="#FFF" />
      </Link>

    </div>
  );
}

export default OrphanagesMap;
