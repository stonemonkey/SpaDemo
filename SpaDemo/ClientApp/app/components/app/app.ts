import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'SPA Demo';
        config.map([{
            route: 'home',
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: ['', 'customers'],
            name: 'customers',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../customers/customers'),
            nav: true,
            title: 'Customers'
        }]);

        this.router = router;
    }
}
