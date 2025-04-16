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

## Desenho da arquitetura
![Desenho da Arquitetura](HealthMed\img\desenho.jpg)

    
## Rodando o Projeto
- Buildar as imagens da API e do consumidor pois o projeto est� apontando para uma imagem local

    docker build -f .\dockerfile-api -t api:v1 .
    docker build -f .\dockerfile-worker -t worker:v1 .

- Subir volumes
    ...

- Subir os pods, que � onde roda as aplica��es. Nesse projetos criamos um arquivo para da pod: Menssageria (RabbtMq), Banco (SQL), API e Consumidor

    kubectl apply -f sql.yaml
    kubectl apply -f menssageria.yaml
    kubectl apply -f api.yaml
	
- Subir os servi�os, que � onde expoem as portas. Foi criado quatro services um para cara pod

    kubectl apply -f svc-sql.yaml
    kubectl apply -f svc-menssageria.yaml
    kubectl apply -f svc-api.yaml
	kubectl apply -f svc-worker.yaml

Para acessar a aplica��o utilizar: http://localhost:32100/swagger/index.html
    para logar: usuario: usuario-fiap | senha: senha-fiap

Para conectar ao banco de dados: Server: localhost,32200 | User: sa | Password: Passw0rd

Para acessar o RabbitMq utilizar: http://localhost:31672 | User: guest | Password: guest


- Para ver os Pod e os Services rodando 
    kubectl get all

- Para ver os pv rodando
    kubectl get pv

- Para ver os pvc rodando
    kubectl get pvc
