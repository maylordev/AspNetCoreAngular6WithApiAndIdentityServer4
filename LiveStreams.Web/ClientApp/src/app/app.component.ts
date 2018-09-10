import {Component, ElementRef} from '@angular/core';
import {PreloadService} from './core/preload/preload.service';
import {LoggerService} from './core/logger/logger.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(
    preloadService: PreloadService<any>,
    elementRef: ElementRef,
    logger: LoggerService
  ) {
    logger.info('Starting App.Component');

    preloadService.data = JSON.parse(
      elementRef.nativeElement.getAttribute('data-init')
    );
  }
  title = 'app';
}
