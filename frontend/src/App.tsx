import { useState } from "react";
import { Button, Avatar } from "antd";
import { Link } from "react-router-dom";
import hero from "./Components/Hero/hero.png"; // Imagem do herói
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";

export function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <section id="hero" style={{ padding: "80px 0", width: "100%" }}>
        <div
          className="container"
          style={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "center",
            alignItems: "center",
            maxWidth: "1200px",
            margin: "0 auto",
          }}
        >
          <div
            className="text-content"
            style={{
              maxWidth: "600px",
              textAlign: "center",
              marginBottom: "30px",
            }}
          >
            <h3 style={{ fontSize: "36px", fontWeight: "bold", color: "#333" }}>
              Um pouco sobre mim
            </h3>
            <p
              style={{
                fontSize: "18px",
                color: "#555",
                marginTop: "20px",
                fontFamily: "monospace",
              }}
            >
              Atualmente sou desenvolvedor .Net pleno pela vivo, sou responsável pela manutenção e criação de novas features de aplicações que criei do 0.
            </p>
            <p
              style={{
                fontSize: "14px",
                color: "#777",
                marginTop: "20px",
                marginInline: "22px",
                fontFamily: "monospace",
              }}
            >
Técnologo em Análise e desenvolvimento de software pelo SENAC/Porto Digital e Barcharel em Ciência da Computação pela UNIFG, atualmente estou atuando como Full-Stack porém tenho mais afinidade com Back-end, minha principal linguagem é C# e tenho muita experiência com ferramentas .NET (MAUI, Blazor etc).
            </p>
            <div style={{ marginTop: "30px" }}>
              <Link to="https://www.linkedin.com/in/jhonny-mello-194a111b0/">
                <Button
                  type="primary"
                  size="large"
                  style={{
                    backgroundColor: "#32cd32",
                    borderColor: "#32cd32",
                    padding: "10px 20px",
                  }}
                >
                  Linkedin
                </Button>
              </Link>
              <Link to="https://github.com/Jhonny-Mello">
                <Button
                  type="primary"
                  size="large"
                  style={{
                    marginLeft:"30px",
                    backgroundColor: "#32cd32",
                    borderColor: "#32cd32",
                    padding: "10px 20px",
                  }}
                >
                  GitHub Pessoal
                </Button>
              </Link>
              <Link to="https://github.com/JhonnyMelloTelefonica">
                <Button
                  type="primary"
                  size="large"
                  style={{
                    marginLeft:"30px",
                    backgroundColor: "#32cd32",
                    borderColor: "#32cd32",
                    padding: "10px 20px",
                  }}
                >
                  GitHub Telefonica
                </Button>
              </Link>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
