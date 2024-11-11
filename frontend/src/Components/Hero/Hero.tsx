import React from "react";
import { Avatar, Button } from "antd";
import { Link } from "react-router-dom";
import hero from "./hero.png"; 
import "./Hero.css"; 
interface Props {}

const Hero: React.FC<Props> = () => {
  return (
    <section id="hero" style={{ backgroundColor: '#f5f5f5', padding: '80px 0', width: '100%' }}>
      <div className="container" style={{ display: 'flex', flexDirection: 'row', justifyContent: 'center', alignItems: 'center', maxWidth: '1200px', margin: '0 auto' }}>
        <div className="text-content" style={{ maxWidth: '600px', textAlign: 'center', marginBottom: '30px' }}>
          <h1 style={{ fontSize: '36px', fontWeight: 'bold', color: '#333' }}>
            Fórum FSBR Test
          </h1>
          <p style={{ fontSize: '22px', color: '#555', marginTop: '20px', fontFamily: 'monospace' }}>
            Bem vindo, me chamo Jhonny e minha proposta de aplicação para o teste é um simples fórum.
          </p>
          <p style={{ fontSize: '14px', color: '#777', marginTop: '20px', marginInline: '22px', fontFamily: 'monospace' }}>
            Neste fórum é possivel realizar publicações e avaliar ou comentar outras publicações, e é claro edita-las ou exclui-las.
          </p>
          <div style={{ marginTop: '30px' }}>
            <Link to="/login">
              <Button type="primary" size="large" style={{ backgroundColor: '#32cd32', borderColor: '#32cd32', padding: '10px 20px' }}>
                Let's go
              </Button>
            </Link>
          </div>
        </div>
        <div className="image-content" style={{ marginLeft: '30px' }}>
          <Avatar size={180} src={hero} alt="Hero" style={{ display: 'block', margin: '0 auto' }} />
        </div>
      </div>
    </section>
  );
};

export default Hero;
