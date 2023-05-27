```plantuml
package Core {
    class Helper
    class Extension
}
package Application {
    class LifetimeScope
    class Signal
}
package Entities {
    class Entity
    interface IEntity
    Entity -|> IEntity
}
package Gateway {
    class Gateway
    interface IGateway
    Gateway -|> IGateway
}
package Presenters {
    class Presenter
    interface IPresenter
    Presenter -|> IPresenter
}
package Models {
    class Model
    interface IModel
    Model -|> IModel
}
package Views {
    class View
    interface IView
    View -|> IView
}
Gateway.Gateway --> Entities.Entity

Presenters.Presenter --> Models.IModel
Presenters.Presenter --> Views.IView

Models.Model --> Entities.Entity
Models.Model --> Gateway.IGateway
```