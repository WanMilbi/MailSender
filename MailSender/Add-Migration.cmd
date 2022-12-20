
set /p name=enter migration name:
dotnet ef migrations add %name% --context MailSenderDBContextInitializer  --startup-project  ../MailSender.App
pause