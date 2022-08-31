import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

    navigation: any;
    isOpened: boolean = true;
    buttonOptions: any;
 
    constructor(private router: Router) {
        this.buttonOptions = {
            icon: "menu",
            onClick: () => {
                this.isOpened = !this.isOpened;
            }
        };
        this.navigation = [
            { id: 1, text: "Categorias", icon: "help", filePath: "categorias" },
            { id: 2, text: "Productos", icon: "box", filePath: "productos" },
            { id: 3, text: "Clientes", icon: "user", filePath: "clientes" },
            { id: 4, text: "Ventas", icon: "money", filePath: "ventas" }
        ];
    }
 
    loadView(e: any) {
        this.router.navigate([e.addedItems[0].filePath])
    }

}
