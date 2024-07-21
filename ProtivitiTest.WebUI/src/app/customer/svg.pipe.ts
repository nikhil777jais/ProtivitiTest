import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'svg'
})
export class SvgPipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer){

  }

  transform(avatar: string): SafeHtml {
    if(undefined)
      return ""
    const parser = new DOMParser();
    avatar?.replaceAll('\\','');
    const svgDoc = parser.parseFromString(avatar, 'image/svg+xml');
    const svgElement = svgDoc.documentElement;
    return this.sanitizer.bypassSecurityTrustHtml(svgElement.outerHTML);
  }

}
