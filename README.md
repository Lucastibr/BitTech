# Esse projeto foi criado com .Net 9

# Desafio BitTech - Passo a Passo para Execução

Este é um passo a passo para executar a aplicação em seu ambiente local, seja no Windows ou no Linux. O projeto foi desenvolvido com .Net 9 e pode ser executado facilmente após a instalação das ferramentas necessárias.

## Pré-requisitos

Antes de começar, você precisará ter as seguintes ferramentas instaladas:

- .NET SDK (9.x ou superior)
- Git (para clonar o repositório)
- Visual Studio Code 

### Instalação das Ferramentas

#### Windows

1. Instalar o .NET SDK:
   - Acesse o site oficial para baixar o **.NET SDK**: [https://dotnet.microsoft.com/download/dotnet](https://dotnet.microsoft.com/download/dotnet).
   - Execute o instalador e siga as instruções.

2. Instalar o Git:
   - Baixe o Git em [https://git-scm.com/downloads](https://git-scm.com/downloads) e siga as instruções do instalador.

3. Instalar o Visual Studio Code:
   - Baixe e instale o [VS Code](https://code.visualstudio.com/)

#### Linux (Ubuntu)

1. Instalar o .NET SDK:
   - Execute os seguintes comandos no terminal para instalar o .NET SDK no Ubuntu:

     ```bash
     sudo apt-get update
     sudo apt-get install -y wget apt-transport-https software-properties-common
     sudo wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list
     sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
     sudo apt-get update
     sudo apt-get install -y dotnet-sdk-9.0
     ```

2. Instalar o Git:
   - No terminal, execute o seguinte comando:

     ```bash
     sudo apt install git
     ```

3. Instalar o Visual Studio Code:
   - Baixe e instale o [VS Code](https://code.visualstudio.com/) no Linux, ou use o comando abaixo:

     ```bash
     sudo apt install code
     ```

### Clonando o Repositório

1. Abra o terminal (ou PowerShell no Windows).
2. Clone o repositório para sua máquina local:

   ```bash
   git clone [https://github.com/Lucastibr/BitTech.git](https://github.com/Lucastibr/BitTech)
   cd BitTech
