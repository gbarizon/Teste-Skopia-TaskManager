# Teste-Skopia-TaskManager
O time de desenvolvimento de uma empresa precisa de sua ajuda para criar um sistema de gerenciamento de tarefas. O objetivo é desenvolver uma API que permita aos usuários organizar e monitorar suas tarefas diárias, bem como colaborar com colegas de equipe.

*** Executando o Projeto no Docker ***

1  - docker-compose up --build

2  - docker start taskmanagerapi-api-1 (isso porque o projeto não subiu automaticamente, devido ao tempo de entrega, eu optei por colocar manualmente até achar uma solução)

Fase 2: Refinamento

Perguntas para o PO para Futuras Melhorias

1 - O histórico das tarefas deve registrar também a criação da tarefa (ex: “Tarefa criada”) ou apenas alterações posteriores?

2 - O que deve acontecer com as tarefas ao excluir um projeto? Elas também devem ser removidas?

3 - Os comentários podem ser editados ou apenas adicionados/excluídos?

4 - Quais permissões mínimas o sistema deve ter? (Ex: todo usuário pode criar/editar/excluir tarefas e comentários?)

5 - Alguma ação (exclusão de tarefas, alteração de status) deve ser restrita a algum tipo de usuário?

6 - Há necessidade de exportar dados ou relatórios no sistema?

7 - Precisamos registrar no histórico outros eventos além das alterações principais (por exemplo, mudança de status, prazos, etc)?

Fase 3: Pontos de Melhoria e Evolução Arquitetural
Tratamento de Erros: Implementar middleware para capturar e retornar erros padronizados.

Logs e Monitoramento: Adicionar logs estruturados (ex: Serilog) e ferramentas de monitoramento.

Variáveis Sensíveis: Gerenciar secrets e strings de conexão via variáveis de ambiente ou vault.

Automação DevOps: Configurar pipelines CI/CD para build, testes e deploy automático.

Padronização: Usar lint e análise estática de código para garantir qualidade.

Arquitetura
Projeto segue Clean Architecture, separado em camadas.

Está pronto para deploy em cloud/container.

Recomenda-se no futuro: adicionar autenticação JWT, e se necessário, mensageria para microserviços.


