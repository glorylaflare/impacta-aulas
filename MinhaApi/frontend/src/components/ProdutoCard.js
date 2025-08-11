// src/components/ProdutoCard.js
import React from 'react';
import './ProdutoCard.css'; // Vamos criar este arquivo de estilo a seguir

// Este componente recebe um objeto "produto" através das props
function ProdutoCard({ produto }) {

  // Formata o preço para o padrão brasileiro (ex: R$ 7.500,50)
  const precoFormatado = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(produto.preco);

  return (
    <div className="card">
      <div className="card-body">
        <h3 className="card-title">{produto.nome}</h3>
        <p className="card-price">{precoFormatado}</p>
        {/* Futuramente, os botões de Editar e Excluir virão aqui */}
      </div>
    </div>
  );
}

export default ProdutoCard;