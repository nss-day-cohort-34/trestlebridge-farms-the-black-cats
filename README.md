![trestlebridge farm landscape](./Trestlebridge.jpg)

# Welcome to Trestlebridge Farms!

## Farm Animals and Raw Materials System (FARMS)

Fancy web applications are so 2017. Command line applications provide a much more hands-on, personal, bespoke, artisinal experience when managing a farm such as Trestlebridge. Therefore, even though our team has decided to lead a life connected with the land, we still want to use our hard-earned skills as developers to make management of our farm as efficient as possible.

Here are the main features of the application.

### Main Menu

When the user first executes FARMS, they are welcomed to the system and presented with the following menu.

    ```sh
    +-++-++-++-++-++-++-++-++-++-++-++-++-+
    |T||r||e||s||t||l||e||b||r||i||d||g||e|
    +-++-++-++-++-++-++-++-++-++-++-++-++-+
            |F||a||r||m||s|
            +-++-++-++-++-+

    1. Create Facility
    2. Purchase Animals
    3. Purchase Seeds
    4. Processing Options (this is a stretch goal)

    Choose a FARMS option.
    > _
    ```

### Facility Creation Options Sub-Menu

If the user chooses option 1, then the following menu is displayed

    ```sh
    1. Grazing field
    2. Plowed field
    3. Natural field
    4. Chicken house
    5. Duck house

    Choose what you want to create.
    > _
    ```

When the user makes a choice, a new instance of that type of facility is added to a `List<>` on the farm.

### Animal Purchase Menu

If the user chooses 2 from the main menu, then the following menu will appear, with the animals listed.

    ```sh
    1. Chicken
    2. Cow
    3. Duck
    4. Goat
    5. Ostrich
    6. Pig
    7. Sheep

    Choose animals to purchase.
    > _
    ```

When the user enters in what to buy, then locations that have enough capacity to house the animal and are appropriate for the animal will be displayed. The current number of animals is displayed for each location.

    ```sh
    1. Grazing Field (16 animals)
    2. Grazing Field (4 animals)

    Where would you like to place the animals?
    > _
    ```

### Seed Purchase Menu

If the user chooses 3 from the main menu, then the following menu will display, with the plants listed. The user can purchase enough seeds for an entire row at a time.

    ```sh
    1. Sesame
    2. Sunflower
    3. Wildflower

    Choose seed to purchase.
    > _
    ```

When the user makes a choice, then locations that have enough capacity to house the plant and are appropriate for the plant will be displayed. The current number of plant rows is displayed for each location.

    ```sh
    1. Plowed Field (8 rows of plants)
    2. Plowed Field (5 rows of plants)
    3. Natural Field (0 rows of plants)

    Where would you like to plant the Sunflowers?
    > _
    ```

### Processing Menu

If the user choose 4 from the main menu, the following options will be displayed.

    ```sh
    1. Seed Harvester
    2. Meat Processor
    3. Egg Gatherer
    4. Composter
    5. Feather Harvester

    Choose equipment to use.
    > _
    ```

When the user selects a piece of equipment, then the current facilities that contain plants or animals that can be processed by that equipment are displayed.

For example, if Meat Processor is selected, the following will be presented.

    ```sh
    1. Grazing Field (20 animals)
    2. Chicken House (13 animals)

    Which facility has the animals you want to process?
    > _
    ```

Once the storage facility is chosen, then the type of things in that facility will be listed.

    ```sh
    1. 2 Ostrich
    2. 13 Cow
    3. 4 Pig
    4. 11 Goat
    5. 7 Sheep

    Which resource should be processed?
    > _
    ```

Lastly, when the type is chosen, the user will enter how many resources they wish to process.

    ```sh
    How many Sheep should be processed?
    > _
    ```

1. The program will then verify that the equipment has the capacity to handle that many resources.
1. If it can, the user will be asked to indicate if they are done or want to add more animals.

    ```sh
    Ready to process? (Y/n)
    > _
    ```

1. If user is done, _n_ of that type will be removed from the storage facility, and _n_ will be added to the equipment resource list.
2. The result of processing the resources will then be displayed.
3. If the user is **not** done, the user will be returned to the menu showing storage facility options again.
    ```sh
    1. Grazing Field (20 animals)
    2. Chicken House (13 animals)
    3. Duck House (7 animals)

    Which facility has the animals you want to process?
    > _
    ```