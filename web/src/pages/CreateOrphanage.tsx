import React, { ChangeEvent, FormEvent, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Map, Marker, TileLayer } from 'react-leaflet';
import { FiPlus, FiX } from "react-icons/fi";
import { LeafletMouseEvent } from 'leaflet';

import api from "../services/api";

import Sidebar from "../components/SideBar";
import mapIcon from "../utils/mapIcon";

import '../styles/pages/create-orphanage.css';
import axios, { AxiosRequestConfig } from "axios";
import { BASE_URL } from "../utils/requests";
import { OrphanageRequest } from "../types/OrphanageRequest";

interface PreviewImage {
  name: string;
  url: string;
}

const CreateOrphanage = () => {
  const history = useHistory();

  const [orphanages, setOrphaanges] = useState<OrphanageRequest[]>([]);

  useEffect(() => {
    const params: AxiosRequestConfig = {
      method: 'POST',
      url: `/orphanages/insert`,
      baseURL: BASE_URL
    };
    axios(params)
      .then((response) => {
        setOrphaanges(response.data);
      })
  }, []);


  const [position, setPosition] = useState({ latitude: 0, longitude: 0 });

  const [name, setName] = useState('');
  const [about, setAbout] = useState('');
  const [instructions, setInstructions] = useState('');
  const [whatsapp, setWhatsapp] = useState('');
  const [opening_hours, setOpeningHours] = useState('');
  const [open_on_weekends, setOpenOnWeekends] = useState(true);
  const [images, setImages] = useState<File[]>([]);
  const [previewImages, setPreviewImages] = useState<PreviewImage[]>([]);

  function handleMapClick(event: LeafletMouseEvent) {
    const { lat, lng } = event.latlng;

    setPosition({
      latitude: lat,
      longitude: lng
    });
  }

  async function handleSubmit(event: FormEvent) {
    event.preventDefault();

    const { latitude, longitude } = position;

    const data = new FormData();

    data.append('name', name);
    data.append('about', about);
    data.append('whatsapp', whatsapp);
    data.append('latitude', String(latitude));
    data.append('longitude', String(longitude));
    data.append('instructions', instructions);
    data.append('opening_hours', opening_hours);
    data.append('open_on_weekends', String(open_on_weekends));

    images.forEach(image => {
      data.append('images', image);
    });

    await api.post('orphanages/insert', data)
      .then(res => console.log(res))
    alert('Orfanato cadastrado com sucesso!');
    history.push('/app');
  }

  function handleSelectImages(event: ChangeEvent<HTMLInputElement>) {
    if (!event.target.files) {
      return;
    }
    const selectedImages = Array.from(event.target.files);

    event.target.value = "";

    setImages([...images, ...selectedImages]);

    const selectedImagesPreview = selectedImages.map(image => {
      return { name: image.name, url: URL.createObjectURL(image) };
    });

    //quando state é um array, usar a notação de spread, criando um novo array com todos os elementos
    setPreviewImages([...previewImages, ...selectedImagesPreview]);
  }

  function handleRemoveImage(image: PreviewImage) {
    setPreviewImages([...previewImages, ...previewImages.map((image) => image).filter((img) => img.url !== image.url)]
    );
    setImages(
      images.map((image) => image).filter((img) => img.name !== image.name)
    );
  }

  return (
    <div id="page-create-orphanage">
      <Sidebar />

      <main>
        <form onSubmit={handleSubmit} className="create-orphanage-form">
          <fieldset>
            <legend>Dados</legend>

            <Map
              center={[-22.9035, -43.2096]}
              style={{ width: '100%', height: 280 }}
              zoom={15}
              onclick={handleMapClick}
            >
              <TileLayer
                url={`https://a.tile.openstreetmap.org/{z}/{x}/{y}.png`}
              />

              {position.latitude !== 0 && (
                <Marker
                  interactive={false}
                  icon={mapIcon}
                  position={[
                    position.latitude,
                    position.longitude
                  ]}
                />
              )}

            </Map>

            <div className="input-block">
              <label htmlFor="name">Nome</label>
              <input
                id="name"
                value={name}
                onChange={event => setName(event.target.value)}
              />
            </div>

            <div className="input-block">
              <label htmlFor="whatsapp">Whatsapp</label>
              <input
                id="whatsapp"
                value={whatsapp}
                onChange={event => setWhatsapp(event.target.value)}
              />
            </div>

            <div className="input-block">
              <label htmlFor="about">Sobre <span>Máximo de 300 caracteres</span></label>
              <textarea
                id="name"
                maxLength={300}
                value={about}
                onChange={event => setAbout(event.target.value)}
              />
            </div>

            <div className="input-block">
              <label htmlFor="images">Fotos</label>

              <div className="images-container">
                {previewImages.map((image) => {
                  return (
                    <div key={image.url}>
                      <span
                        className="remove-image"
                        onClick={() => handleRemoveImage(image)}
                      >
                        <FiX size={18} color="#ff669d" />
                      </span>
                      <img src={image.url} alt={name} className="new-image" />
                    </div>
                  );
                })}

                <label htmlFor="image[]" className="new-image">
                  <FiPlus size={24} color="#15b6d6" />
                </label>
              </div>

              <input
                type="file"
                multiple
                accept=".png, .jpg, .jpeg"
                onChange={handleSelectImages}
                id="image[]"
              />
            </div>
          </fieldset>

          <fieldset>
            <legend>Visitação</legend>

            <div className="input-block">
              <label htmlFor="instructions">Instruções</label>
              <textarea
                id="instructions"
                value={instructions}
                onChange={event => setInstructions(event.target.value)}
              />
            </div>

            <div className="input-block">
              <label htmlFor="opening_hours">Horário de Funcionamento</label>
              <input
                id="opening_hours"
                value={opening_hours}
                onChange={event => setOpeningHours(event.target.value)}
              />
            </div>

            <div className="input-block">
              <label htmlFor="open_on_weekends">Atende fim de semana</label>

              <div className="button-select">
                <button
                  type="button"
                  className={open_on_weekends ? 'active' : ''}
                  onClick={() => setOpenOnWeekends(true)}
                >
                  Sim
                </button>
                <button
                  type="button"
                  className={!open_on_weekends ? 'active' : ''}
                  onClick={() => setOpenOnWeekends(false)}
                >
                  Não
                </button>
              </div>
            </div>
          </fieldset>

          <button className="confirm-button" type="submit">
            Confirmar
          </button>
        </form>
      </main>
    </div>
  );
}

export default CreateOrphanage;