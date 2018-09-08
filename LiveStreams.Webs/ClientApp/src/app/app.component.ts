import {Component, ElementRef} from '@angular/core';
import {PreloadService} from './core/preload/preload.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(
    preloadService: PreloadService<any>, 
    elementRef: ElementRef
    ){
    preloadService.data = JSON.parse(elementRef.nativeElement.getAttribute('data-init'));
  }
  title = 'app';
}
