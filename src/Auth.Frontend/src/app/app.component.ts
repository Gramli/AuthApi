import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, ToastModule,],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    providers: [MessageService]
})
export class AppComponent {
}
