# Hackathon 4NETT - Health&Med 

Entrega do Hackathon da fase 5 da PosTech Fiap do *grupo 32*

 - Mayara Alves da Silva - RM 357738
 - Felipe Gonçalves - RM 357046

*Objetivo do projeto:* 
    É criar um sistema robusto, escalável e seguro que permita o gerenciamento eficiente de agendamentos e consultas via telemedicina. 

Esse projeto utiliza
- .Net8
- Sql Server
- RabbitMq
- Kubernets

## Arquitetura Utilizada 

A arquitetura adotada segue o modelo em camadas com uso de microserviços. Utilizamos mensageria para a comunicação entre os serviços, enviando mensagens para uma fila, onde um consumidor as processa e realiza a gravação no banco de dados.
Cada microserviço é responsável por uma funcionalidade específica e opera de forma totalmente isolada dos demais, garantindo uma estrutura desacoplada e de fácil manutenção.
Para garantir escalabilidade e resiliência ao ambiente, utilizamos o Kubernetes como orquestrador de containers.

    
## Rodando o Projeto
