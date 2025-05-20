# 🏥 Sistema de Gerenciamento de Clínica Médica (Console - C# .NET)

## 📌 Descrição

Este projeto é um sistema de gerenciamento de clínica médica desenvolvido em C# com foco em **arquitetura orientada a casos de uso** e **Programação Orientada a Objetos (POO)**.  
O sistema funciona via console, com uma estrutura modular e escalável, permitindo:

-    Cadastro de pacientes e funcionários
-    Agendamento e listagem de consultas
-    Registro de auditoria
-    Gerenciamento de múltiplos papéis por pessoa (CPF único como base)

---

## ✅ Funcionalidades

-    Cadastrar **pacientes** com nome, documento, nascimento e convênio
-    Cadastrar **funcionários** com nome, documento, nascimento e cargo
-    **Permitir que a mesma pessoa tenha múltiplos papéis** (paciente e funcionário)
-    **Agendar consultas** entre paciente e funcionário
-    **Registrar auditoria** automática ao criar uma consulta
-    **Listar todas as pessoas** e **consultas agendadas**
-    Navegação simples por menu interativo

---

## 🧱 Estrutura e Padrões Arquiteturais

### 🧭 Modularização

clinica-console/
├── app/console/ # Interface de console
├── core/
│ └── modules/
│ ├── people/ # Pessoas, pacientes, funcionários
│ │ ├── models/entities/
│ │ └── use-cases/
│ └── appointments/ # Consultas médicas
│ ├── models/entities/
│ ├── interfaces/
│ └── use-cases/
└── README.md

### 🧠 Princípios aplicados

| Conceito            | Aplicação                                                                |
| ------------------- | ------------------------------------------------------------------------ |
| Abstração           | `Person` é abstrata e define o contrato base para `Patient` e `Employee` |
| Herança             | `Patient` e `Employee` herdam de `Person`                                |
| Encapsulamento      | Atributos privados e propriedades com validações                         |
| Polimorfismo        | Lista de `Person` usada para armazenar todos os papéis                   |
| Interface           | `IAuditable` implementada por `Appointment`                              |
| Separação de papéis | Um mesmo CPF pode ser paciente e funcionário                             |
| Casos de uso        | Cada ação (cadastro, listagem, agendamento) encapsulada em uma classe    |

---

## 📦 Casos de Uso Implementados

| Módulo         | Casos de uso                 | Descrição                                      |
| -------------- | ---------------------------- | ---------------------------------------------- |
| `People`       | `RegisterPatientUseCase`     | Cadastra novo paciente ou converte funcionário |
|                | `RegisterEmployeeUseCase`    | Cadastra funcionário ou converte paciente      |
|                | `ListPersonUseCase`          | Lista todas as pessoas cadastradas             |
| `Appointments` | `ScheduleAppointmentUseCase` | Agendamento interativo de consulta             |
|                | `ListAppointmentsUseCase`    | Exibe todas as consultas agendadas             |

---

## 🖥️ Como Executar o Projeto

### ✅ Requisitos:

-    .NET SDK 6.0 ou superior  
     Verifique com:
     ```bash
        dotnet --version
     ```

## ▶️ Execução:

-    Clone o repositório ou navegue até a pasta

-    No terminal:

     ```bash
          dotnet run --project app/console/
     ```

-    Use o menu interativo no terminal.

## 📌 Regras de Negócio Especiais

-    O documento (CPF) é único no sistema: uma pessoa pode ser paciente, funcionário, ou ambos

-    Ao tentar cadastrar alguém com CPF já existente, o sistema pergunta se deseja adicionar outro papel

## 🔎 Exemplos de Fluxo

-    Um paciente pode ser promovido a funcionário sem duplicar cadastro

-    O agendamento de consulta exige seleção de paciente e funcionário válidos

-    Auditoria (CreatedAt, CreatedBy) é registrada automaticamente nas consultas

## 👨‍💻 Desenvolvedor

-    Projeto acadêmico com fins didáticos.

**Vinícius Gabriel Todis**
Análise e Desenvolvimento de Sistemas — 2025
