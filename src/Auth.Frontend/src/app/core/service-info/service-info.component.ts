import { Component, OnInit, signal, WritableSignal, ChangeDetectionStrategy } from '@angular/core';
import { ServiceInfoService } from './service-info.service';
import { IServiceInfo } from './service-info.model';
import { AccordionModule } from '@openng/optimus-ui/accordion';

@Component({
    selector: 'app-service-info',
    imports: [AccordionModule],
    templateUrl: './service-info.component.html',
    changeDetection: ChangeDetectionStrategy.Eager,
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
