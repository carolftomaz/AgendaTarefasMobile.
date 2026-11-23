MINHA AGENDA - TRABALHO FINAL DESENVOLVIMENTO MOBILE

1. Abra o arquivo AgendaTarefasMobile.csproj no Visual Studio Community 2026.
2. Instale a carga de trabalho Desenvolvimento de interface do usuário de aplicativo multiplataforma .NET (.NET MAUI) no Visual Studio Installer, se estiver faltando.
3. Use um celular Android físico com Depuração USB habilitada e conectado por USB. Evite o emulador neste notebook de 4 GB de RAM.
4. Selecione o dispositivo Android e execute o projeto. Na primeira abertura, o banco SQLite será criado com três categorias iniciais.
5. Abra Tarefas para cadastrar, pesquisar, editar, concluir e excluir tarefas.
6. Abra Categorias para cadastrar, editar e excluir categorias não utilizadas por tarefas.
7. Abra Histórico para consultar os registros de ações.
8. O menu lateral abre as outras seções e a tela Sobre.

ARQUITETURA
Models: tabelas TaskItem, CategoryItem, ActivityItem.
Data: AgendaDatabase, DAO equivalente com SQLite.
ViewModels: lógica e dados das telas no padrão MVVM.
Views: telas XAML e navegação.
Services: acesso compartilhado ao banco e mensagens rápidas.

REQUISITOS
Label, Entry, Editor, Button, CheckBox, RadioButton, Image, Grid, ListView, Toast Android, SearchBar, DatePicker e Picker.
Navegação: FlyoutPage, TabbedPage, NavigationPage e página modal ContentPage.
CRUD de tarefas e categorias, validação, filtro em tempo real, confirmação de exclusão, três tabelas e MVVM.

IMPORTANTE
Projeto preparado para Android com .NET 10 e Visual Studio 2026.
Não foi possível compilar no ambiente de criação, porque o SDK do .NET MAUI não está instalado aqui.
É necessário abrir e compilar no Visual Studio, corrigir eventuais erros de ambiente e testar no aparelho antes de entregar.
Os prints reais para a documentação precisam ser capturados com o aplicativo rodando.
A entrega pede PDF com descrição e prints e código-fonte via GitHub ou ZIP.
