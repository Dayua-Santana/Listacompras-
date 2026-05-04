# 🛒 Gerenciador de Lista de Compras

Sistema de console desenvolvido em C# para gestão de listas de compras, permitindo o controle de produtos, categorias e itens vinculados a listas específicas.

## 🚀 Funcionalidades

- **Gestão de Produtos:** Cadastro de itens com nome, categoria e preço aproximado.
- **Categorização:** Organização de produtos por categorias específicas.
- **Listas de Compras:** 
    - Criação de novas listas.
    - Adição e remoção de itens (com validação para não repetir o mesmo produto).
    - Cálculo automático do total de itens e valor estimado.
    - Status de controle (Aberta/Concluída).
- **Notificações:** Sistema de mensagens coloridas para erros e sucessos no console.

## 🛠️ Tecnologias e Conceitos

- **Linguagem:** C# (.NET)
- **Arquitetura:** Programação Orientada a Objetos (POO).
- **Padrões:** Uso de repositórios para persistência em memória e telas para interação com o usuário.
- **Recursos C#:** Generics, LINQ, Herança e Polimorfismo.

## 📁 Estrutura do Projeto

O projeto está dividido em módulos para facilitar a manutenção:
- `ModuloProduto`: Gerenciamento de itens cadastráveis.
- `ModuloListaCompras`: Cabeçalho e informações gerais da lista.
- `ModuloItemLista`: Gestão dos itens específicos dentro de cada lista.
- `Compartilhado`: Classes base, repositórios genéricos e utilitários de tela.

## ⚙️ Como executar

1. Certifique-se de ter o SDK do .NET instalado em sua máquina.
2. Clone o repositório:
   ```bash
   git clone [https://github.com/Dayua-Santana/Listacompras-.git](https://github.com/Dayua-Santana/Listacompras-.git)