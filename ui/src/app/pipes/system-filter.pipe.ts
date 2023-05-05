import { Pipe, PipeTransform } from '@angular/core';
import { SystemDto } from '../models/systemDto';

@Pipe({
  name: 'systemFilter'
})
export class SystemFilterPipe implements PipeTransform {

  transform(value: SystemDto[], filterText: string): SystemDto[] {
    filterText.toLowerCase() ? filterText :""
    return filterText ? value.filter((s:SystemDto) =>s.name.toLowerCase().indexOf(filterText) !== -1):value
  }

}
