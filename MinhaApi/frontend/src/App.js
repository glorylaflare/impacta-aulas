// src/App.js

import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ProdutoCard from './components/ProdutoCard'; // 1. Importe o novo componente
import './App.css'; // Importa o estilo do App

function App() {
  const [produtos, setProdutos] = useState([]);
  const [status, setStatus] = useState('Carregando...');

  useEffect(() => {
    // Lembre-se de usar a porta correta da sua API .NET
    const apiUrl = 'https://localhost:7048/api/produtos'; 

    async function buscarProdutos() {
      try {
        const response = await axios.get(apiUrl);
        setProdutos(response.data);
        setStatus('');
      } catch (error) {
        console.error("Erro ao buscar produtos:", error);
        if (error.response) {
            // O erro veio do backend (CORS, etc.)
            setStatus(`Erro da API: ${error.message}. Verifique a política de CORS no backend.`);
        } else if (error.request) {
            // O erro é de conexão (API offline)
            setStatus('Erro de conexão. A API .NET está rodando?');
        } else {
            // Outro erro
            setStatus('Ocorreu um erro inesperado.');
        }
      }
    }

    buscarProdutos();
  }, []);

  return (
    <div className="app-container">
      <h1>Catálogo de Produtos</h1>

      {/* Exibe a mensagem de status se houver uma */}
      {status && <p className="status-message">{status}</p>}

      <div className="produtos-grid">
        {/* 2. Mapeia a lista de produtos para renderizar um card para cada um */}
        {produtos.map(produto => (
          <ProdutoCard key={produto.id} produto={produto} />
        ))}
      </div>
    </div>
  );
}

export default App;