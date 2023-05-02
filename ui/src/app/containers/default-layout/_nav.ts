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
    name: 'Colors',
    url: '/dashboard/colors',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'List',
        url: '/dashboard/colors',
      },
      {
        name: 'New Color',
        url: '/dashboard/colors/add',
      }
    ]
  },
  {
    name: 'Brands',
    url: '/dashboard/brands',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Brands',
        url: '/dashboard/brands',
      },
      {
        name: 'New Color',
        url: '/dashboard/brands/add',
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

      },
];
