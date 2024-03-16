# PosTech.TechChallenge.Hackthon.Grupo7

## Introdução

Esse projeto tem como objetivo atender os requisitos do **Hackathon** de conclusão da **FIAP POS TECH**.

## Desafio
O projeto desenvolvido está sem nenhuma das boas práticas de arquitetura de software que nós
aprendemos no curso.
O desafio do seu grupo será desenvolver uma aplicação .NET com C# utilizando os conceitos
apresentados no curso como: DDD, Clean Architecture, Qualidade de Software, Mensageria …etc
E para te ajudar em uma das etapas de levantamento de requisitos, segue alguns dos pré requisitos
esperados para este projeto:

- O Sistema deve processar mais de um vídeo;
- Em caso de picos o sistema não deve perder uma requisição;
- O sistema deve ter uma tela para receber os inputs;
- O sistema deve ter um local de armazenamento de dados, logo precisa de uma tela de
listagem de envios (não precisa ter gerenciamento de dados)

### Requisitos técnicos:
- O sistema deve ter um banco de dados;
- O sistema deve estar em uma arquitetura que o permita ser escalado;
- A tela de input pode estar em um projeto MVC;
- O projeto deve ser disponibilizado no Github para o professor avaliar;
- O projeto deve ter testes unitários;
- O deploy do projeto pode ser local, mas precisa rodar dentro de um Docker Compose ou em
uma arquitetura com Kubernetes (pods, services…etc)

### Entregáveis:
- Documentação do projeto;
- Desenho da arquitetura escolhida do projeto;
- Script de criação do banco de dados;
- Link do Github do projeto; (boas práticas)


## Arquitetura Proposta

Proposta de arquitutura para Upload de arquivo MP4.
![imagem jornada 1](/docs/Jornada_Processo1.jpg "Jornada 1")

Proposta de arquitutura para processamento de Download.
![imagem jornada 2](/docs/Jornada_Processo2.jpg "Jornada 2")