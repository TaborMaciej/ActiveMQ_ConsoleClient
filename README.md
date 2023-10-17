# ActiveMQ_ConsoleClient

Repozytorium składa się z dwóch projektów:
  1) Aplikacja konsolowa producenta wiadomości - umożliwia połączenie i wysłanie wiadomości do kolejki serwera ActiveMQ Artemis.
  2) Aplikacja konsolowa konsumenta wiadomości - umożliwia połączenie i odebranie wiadomości z kolejki serwera ActiveMQ Artemis.

Użyty message broker to Apache Artemis v2.31.0 używający podstawowej konfiguracji. Utworzono w nim kolejkę o nazwie "kolejka".
Aplikacje konsolowe zostały utworzone w technologii .NET Core 6.X, dodatkowo do obu projektów dodano 2 pakiety: "Apache.NMS" v2.0.0 oraz "Apache.NMS.ActiveMQ" v2.0.0.
