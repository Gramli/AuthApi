import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { ServiceInfoService } from './service-info.service';
import { IServiceInfo } from './service-info.model';
import { AccordionModule } from 'primeng/accordion';

@Component({
  selector: 'app-service-info',
  standalone: true,
  imports: [AccordionModule],
  templateUrl: './service-info.component.html',
  styleUrl: './service-info.component.scss'
})
export class ServiceInfoComponent implements OnInit {

  protected serviceInfo: WritableSignal<IServiceInfo | undefined> = signal(undefined);

  constructor(private serviceInfoService: ServiceInfoService){
  }

  ngOnInit(): void {
    this.loadServiceInfo();
  }

  private loadServiceInfo(): void {
    this.serviceInfoService.getServiceInfo().subscribe({
      next: (response)=> {
        this.serviceInfo.set(response.data);
      },
    });
  }

}
