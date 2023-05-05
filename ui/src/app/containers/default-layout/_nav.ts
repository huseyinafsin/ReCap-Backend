import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [

  {
    name: 'Go',
    url: '/home',
    iconComponent: { name: 'cis-speedometer' },
    badge: {
      color: 'info',
      text: '->'
    }
  },
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Cars',
    url: '/dashboard/cars',
    iconComponent: { name: 'cil-speedometer' },
    children: [
      {
        name: 'List',
        url: '/dashboard/cars',
      },
      {
        name: 'New Car',
        url: '/dashboard/cars/add',
      }
    ]
  },
  {
    name: 'Rental',
    url: '/dashboard/rentals',
    iconComponent: { name: 'cil-speedometer' },
    children: [
      {
        name: 'List',
        url: '/dashboard/rentals',
      },
      {
        name: 'New Rental',
        url: '/dashboard/rentals/add',
      }
    ]
  },
  {
    name: 'Customers',
    url: '/dashboard/customers',
    iconComponent: { name: 'cil-people' },
    children: [
      {
        name: 'List',
        url: '/dashboard/customers',
        iconComponent: { name: 'cil-people' },
      },
      {
        name: 'New Customer',
        url: '/dashboard/customers/add',
        iconComponent: { name: 'cil-user-plus' },
      }
    ]
  },
  {
    name: 'Rentals',
    url: '/dashboard/rentals',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'List',
        url: '/dashboard/rentals',
      }
    ]
  },
{
        name: 'Translate',
        url: '/dashboard/translates',
        iconComponent: { name: 'cil-puzzle' },
        children: [
          {
            name: 'List',
            url: '/dashboard/translates',
          },
          {
            name: 'New',
            url: '/dashboard/translates/add',
          }
        ]
      },
      {
        name: 'Options',
        url: '/dashboard/options',
        iconComponent: { name: 'cil-puzzle' },
        children: [
          {
            name: 'Car Type',
            url: '/dashboard/cartype',
          },
          {
            name: 'Gear Type',
            url: '/dashboard/geartype',
          },
          {
            name: 'Fuel Type',
            url: '/dashboard/fueltype',
          },
          {
            name: 'Insurance Type',
            url: '/dashboard/insurancetype',
          },
          {
            name: 'Color',
            url: '/dashboard/colors',
          },
          {
            name: 'Brand',
            url: '/dashboard/brands',
          },
          ]
      },
];
