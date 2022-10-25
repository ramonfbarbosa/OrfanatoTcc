import React from 'react';
import 'bootstrap/dist/css/bootstrap.css'
import '../styles/components/OrphanageCard.css';
import { Link } from 'react-router-dom';
import { ToggleOrphanageRequest } from '../types/ToggleOrphanageRequest';

function formatPhoneNumber(phoneNumberString: string) {
    var cleaned = ('' + phoneNumberString).replace(/\D/g, '');
    var match = cleaned.match(/^(\d{2})(\d{5})(\d{4})$/);
    if (match) {
      return '(' + match[1] + ') ' + match[2] + '-' + match[3];
    }
    return null;
  }

const OrphanageCard = (orphanage: ToggleOrphanageRequest) => {
    const isActive = orphanage.status != true
    let status;
    let ativar;
    if (!isActive){
        status = <h5 className='card-text mb-2 text-muted'>STATUS: DESATIVADO</h5>;
        ativar = <a href="#" className="btn btn-success" >ATIVAR</a>
    }
    if (isActive){
        status = <h5 className='card-text mb-2 text-muted'>STATUS: ATIVADO</h5>;
        ativar = <a href="#" className="btn btn-danger" >DESATIVAR</a>
    }
    
    return (
        <div className="card bg-light mx-2 my-2" style={{ width: '17rem'  }}>
            <div className="card-header" >
                <h3 className='card-title'>ORFANATO Nº #{orphanage.id}</h3>
            </div>
            <div className='card-body text-center'>
                <h5 className='card-text mb-2 text-muted'>{orphanage.name}</h5>
                <h5 className='card-text mb-2 text-muted'>{formatPhoneNumber(orphanage.whatsapp)}</h5>
                <h5 className='card-text mb-2 text-muted'>Abre as: {orphanage.abreAs}</h5>
                <h5 className='card-text mb-2 text-muted'>Abre as: {orphanage.fechaAs}</h5>
                {status}
                <Link to={`/orphanages/${orphanage.id}`}>
                    <a className="card-link btn btn-secondary btn-sm">Mais informacoes</a>
                </Link>
                <hr />
                {ativar}
            </div>
        </div>
    );
}

export default OrphanageCard;