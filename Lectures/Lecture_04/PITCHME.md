@snap[north span-100]
# Persistence
@snapend

@snap[midpoint span-100]
## Storing data in .NET Applications
@snapend

@snap[south-east]
[ Michal Mrnuštík <michal.mrnustik@outlook.com> ]
@snapend


---

## Lecture outline:  
1. Persistence
2. Object relationship mapping (ORM)
3. ORM using Entity Framework Core
4. Architectural patterns of persistence
5. Example of Entity Framework Core setup

---

## Persistence
* Ability to store application data
* Can be achieved using:
    * *Database*
    * *Files*
    * *Another application*

--- 

## Persistence Overview

<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" width="1179px" viewBox="-0.5 -0.5 1179 556" content="&lt;mxfile modified=&quot;2019-02-19T15:41:51.057Z&quot; host=&quot;www.draw.io&quot; agent=&quot;Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.109 Safari/537.36&quot; etag=&quot;qbSdoCejfJuXQ23UYnhl&quot; version=&quot;10.2.4&quot; type=&quot;onedrive&quot;&gt;&lt;diagram id=&quot;VzwX6c1LZ7_3RVeKrXSE&quot; name=&quot;PersistenceOverview&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;jTaEXDrFFR1zGWIXkIXQ&quot; name=&quot;PersistenceDatabaseSQL&quot;&gt;7VpZU+M4EP41edkqUj7iHI/kYHd2YIEJ1O48UYql2CpkyysrxOTXr2TLtyAXrpmlJhTEarVa3f21pG6Lnj0Lkt8ZiPwbChHpWQZMeva8Z1mTsS3+SsJrRnAGiuAxDDOSWRKWeIcU0VDUDYYorjFySgnHUZ3o0jBELq/RAGN0W2dbU1KfNQIeahGWLiBt6t8Ycj+jjq1RSf8DYc/PZzaHk6wnADmzsiT2AaTbCsle9OwZo5RnT0EyQ0T6LvdLkIBvjAy/4uR6trt8XETsZXqRCbs6ZkhhAkMhP1n08/DP6Gn24Nw/BosR3c2dJ//rhZWJfgFko/ylbOWvuQNfEONY+PMarBC5ozHmmIaia0U5p0HPnvo8IKJtisec95JgT/JwGgkqUC1XqI+YIMSc0Wc0o4SK1jykoZhqusaE5KSeZRvGdHFlSWYfRFKVIPFkgPbBbsNQHwIOViCWA5UJYmqUNDDf4zCzQFFEP6IB4uxVjFNSBiMnk6Mi3xqr9raMo6GKDb8SQmNFAypyvUJyiY54UAAdAZa9H6wiRg3hGAhiH0HVqKCkdT9pwFuAtRf/Q0Fv4BjELkD9tDdiOEZ9EEVEyMnEvxkOXaGdI5mDnbcrYJtjDdqm3RXcgxbcDyjhLci5JNbwZSjGO7BKGST0EcUhT7Vzpj1nLsHZcAFkulWbFawIWvM3AY0j4OLQe5CNuVCuOygmVg0K22yvu4EGCasrIBzNuhsS6SmeetkyVpRBlEXq8N+NPBCmZvlYU73oN4S6To3JFbpEAELh5RrroMZVQp8TlfBL0ZlLNTLe3D2arkzlC5cSAiK5j16mh7BqVSYceuo7s3hFRSbQJDKtXivgPnuMbkIop5ErWc4hFjMYuZOBVahS71ynn4aeyoQokRNRIuBKeSfj1doy39HWl/GgwrhkS+O8NShbXdlAESdy7BnS5nJbfU+aJLJDPXmWE2BOmREEwjSToVvEqorAtwd9F9nbe5xH2fFWRCCwtqD9QaAXKk43r2m6iQni6bYUHWz1X/TjjP5IYyD10iyYwi7hk0TdQpf0bMvL6XsPo3qyISx2DfnTPuHVurenVJwoa5JmMZJFHmgyYopMpqtjZ9TIACaaDECX7026OndG+/M9FMJLWSTJfIxQ97ma9Zl1IFCC+T+V5+/SnX1HteaJ8m7aeK007hDDwp70eDN0gBapmVDmKgWsAnxec5X5AoKtgu0Q2OSq2TAX7cuP2/BW8HM08OU0hojIPV/quukwVTPcyayqjJ5CTp61NPPCTH01qlqnNQQ1yw7bcuqCOGAe4i1BaYgVZh8UdS/z++H9xeNNHCzxyI8eHfL0RVtl/Mp2Pl22kw9a0zT43GI9l4xiZctPe+yXeeVAyAS0z4nz0qdz1Gskcj+fgo3c8GAFf0DWcY6Z5gE2vpO5NLadA1dmF4a8mTcfbNWZWdZR/jrFQs42h0Tk/yn5P8cd1im++Bkj970KaKULyE8T0WtA4u5D+seHqv25QrVd337uMP3QjbfLsl0ZcHrZLk1T14PmsKe5IOiqrncalVlR6FcKQ2s40rzaH3xAZa+tsTSv9m/nt0u5VWc4HYmP5gpNkVpebr7cDzCEcprp1sccLSOQlthbBqK9CMq2LkI6u6Kx7H7jSs7WvKOxNEV+Z0i27waWi+vF7EHQfhO/V99ub8SXQvcXqhpUmy9OdNeslqFZnidgKprlfX32wqT8pwd78R8=&lt;/diagram&gt;&lt;diagram id=&quot;Kvzrk7gUgR3qZM4joVvP&quot; name=&quot;PersistenceLoadSQL&quot;&gt;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&lt;/diagram&gt;&lt;/mxfile&gt;" onclick="(function(svg){var src=window.event.target||window.event.srcElement;while (src!=null&amp;&amp;src.nodeName.toLowerCase()!='a'){src=src.parentNode;}if(src==null){if(svg.wnd!=null&amp;&amp;!svg.wnd.closed){svg.wnd.focus();}else{var r=function(evt){if(evt.data=='ready'&amp;&amp;evt.source==svg.wnd){svg.wnd.postMessage(decodeURIComponent(svg.getAttribute('content')),'*');window.removeEventListener('message',r);}};window.addEventListener('message',r);svg.wnd=window.open('https://www.draw.io/?client=1&amp;lightbox=1&amp;edit=_blank');}}})(this);" style="cursor:pointer;max-width:100%;max-height:556px;"><defs/><g><path d="M 859.17 220.78 C 860.25 210.32 867.5 202.09 876.64 200.95 L 974.02 200.95 L 1004.09 235.22 L 1004.09 351.79 C 1003.58 363.25 995.64 372.45 985.64 373.19 L 876.64 373.19 C 867.64 372.09 860.43 364.12 859.17 353.84 Z M 871.02 350.75 C 871.02 354.88 873.56 358.44 877.1 359.27 L 985.87 359.27 C 989.34 358.37 991.81 354.83 991.79 350.75 L 991.79 243.23 L 967.48 243.23 L 967.48 215.04 L 877.1 215.04 C 873.84 215.96 871.5 219.21 871.33 223.04 Z M 897.15 256.1 L 964.29 256.1 L 964.29 270.37 L 897.15 270.37 Z M 897.15 283.24 L 964.29 283.24 L 964.29 297.51 L 897.15 297.51 Z M 897.15 310.38 L 964.29 310.38 L 964.29 324.82 L 897.15 324.82 Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 870.73 554.66 C 854.66 552.84 841.04 541.99 835.64 526.71 C 830.24 511.43 834 494.41 845.34 482.85 C 856.68 471.29 873.6 467.24 888.93 472.4 C 898.8 439.6 933.33 421.03 966.05 430.93 C 998.77 440.82 1017.29 475.44 1007.42 508.24 C 1019.51 507.81 1029.94 516.66 1031.51 528.68 C 1033.08 540.7 1025.27 551.95 1013.49 554.66 C 1013.55 554.49 870.49 555 870.49 555 Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 993.74 137.06 C 993.74 145.92 965.94 153.1 931.63 153.1 C 897.33 153.1 869.53 145.92 869.53 137.06 L 869.53 16.05 C 869.53 7.19 897.33 0 931.63 0 C 965.94 0 993.74 7.19 993.74 16.05 Z M 980.22 19.97 C 980.22 13.9 959.04 8.97 932.9 8.97 C 906.77 8.97 885.58 13.9 885.58 19.97 C 885.58 23.91 894.6 27.54 909.24 29.5 C 923.88 31.47 941.92 31.47 956.56 29.5 C 971.2 27.54 980.22 23.91 980.22 19.97 Z M 916 110.34 C 925.16 106.68 931.06 98.52 931.06 89.52 C 931.06 80.51 925.16 72.35 916 68.69 L 890.65 68.69 L 890.65 110.34 Z M 970.08 110.34 C 974.92 108.43 977.99 103.95 977.8 99.07 C 977.61 94.19 974.21 89.92 969.24 88.34 C 972.44 85.55 973.86 81.42 973 77.42 C 972.14 73.42 969.12 70.12 965.01 68.69 L 941.35 68.69 L 941.35 110.34 Z M 896.57 74.19 L 915.16 74.19 C 921.29 77.17 925.14 83.08 925.14 89.52 C 925.14 95.96 921.29 101.86 915.16 104.84 L 896.57 104.84 Z M 947.27 74.19 L 963.32 74.19 C 965.45 75.5 966.72 77.72 966.72 80.09 C 966.72 82.46 965.45 84.67 963.32 85.98 L 947.27 85.98 Z M 947.27 93.05 L 964.17 93.05 C 967.9 92.62 971.31 95.08 971.77 98.55 C 972.24 102.03 969.59 105.19 965.86 105.63 L 947.27 105.63 Z Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 263.54 269.91 C 263.54 278.7 261.37 285.81 257.03 291.04 C 252.68 296.28 246.83 298.9 239.56 298.9 C 232.67 298.9 227.39 296 223.8 290.11 L 223.61 290.11 L 223.61 321.62 L 215.21 321.62 L 215.21 245.42 L 223.61 245.42 L 223.61 254.58 L 223.8 254.58 C 227.95 247.66 233.99 244.11 242.02 244.11 C 248.62 244.11 253.82 246.44 257.78 251.03 C 261.65 255.7 263.54 261.97 263.54 269.91 Z M 254.95 269.82 C 254.95 264.21 253.63 259.72 250.89 256.36 C 248.25 252.99 244.57 251.31 239.85 251.31 C 235.03 251.31 231.07 252.99 228.05 256.26 C 225.03 259.63 223.52 263.84 223.52 268.98 L 223.52 276.27 C 223.52 280.66 224.93 284.31 227.86 287.3 C 230.78 290.29 234.37 291.7 238.62 291.7 C 243.72 291.7 247.68 289.73 250.61 285.9 C 253.53 282.07 254.95 276.64 254.95 269.82 Z M 202.09 269.91 C 202.09 278.7 199.92 285.81 195.58 291.04 C 191.24 296.28 185.38 298.9 178.11 298.9 C 171.22 298.9 165.94 296 162.35 290.11 L 162.16 290.11 L 162.16 321.62 L 153.76 321.62 L 153.76 245.42 L 162.16 245.42 L 162.16 254.58 L 162.35 254.58 C 166.5 247.66 172.55 244.11 180.57 244.11 C 187.18 244.11 192.37 246.44 196.33 251.03 C 200.11 255.7 202.09 261.97 202.09 269.91 Z M 193.41 269.82 C 193.41 264.21 192.08 259.72 189.35 256.36 C 186.7 252.99 183.02 251.31 178.3 251.31 C 173.49 251.31 169.53 252.99 166.5 256.26 C 163.48 259.63 161.97 263.84 161.97 268.98 L 161.97 276.27 C 161.97 280.66 163.39 284.31 166.32 287.3 C 169.24 290.29 172.83 291.7 177.08 291.7 C 182.17 291.7 186.14 289.73 189.06 285.9 C 191.99 282.07 193.41 276.64 193.41 269.82 Z M 137.72 297.59 L 129.32 297.59 L 129.32 289.45 L 129.13 289.45 C 125.45 295.72 120.06 298.9 112.89 298.9 C 107.79 298.9 103.74 297.49 100.71 294.78 C 97.69 292.07 96.18 288.33 96.18 283.75 C 96.18 274.03 101.94 268.32 113.55 266.73 L 129.32 264.58 C 129.32 255.79 125.73 251.31 118.46 251.31 C 112.14 251.31 106.38 253.46 101.28 257.66 L 101.28 249.06 C 102.79 247.94 105.43 246.82 109.21 245.7 C 112.99 244.67 116.29 244.11 119.22 244.11 C 131.58 244.11 137.81 250.65 137.81 263.65 L 137.81 297.59 Z M 129.32 271.22 L 116.57 273 C 112.23 273.65 109.21 274.68 107.42 276.08 C 105.62 277.49 104.77 279.82 104.77 283.1 C 104.77 285.71 105.72 287.77 107.61 289.36 C 109.49 290.95 111.95 291.7 114.87 291.7 C 119.03 291.7 122.52 290.2 125.26 287.3 C 127.99 284.4 129.32 280.76 129.32 276.36 L 129.32 271.22 Z M 0 162.67 L 0 411.47 L 372.65 411.47 L 372.65 162.67 L 0 162.67 L 0 162.67 Z M 354.06 391.46 L 13.78 391.46 L 13.78 214.84 L 354.06 214.84 L 354.06 391.46 Z" fill="#00bef2" stroke="none" pointer-events="none"/><g transform="translate(67.5,270.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="22" height="12" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; white-space: nowrap;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">Text</div></div></foreignObject><text x="11" y="12" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">Text</text></switch></g><rect x="20.7" y="220.09" width="331.25" height="172.24" fill="#ffffff" stroke="#c0c0c0" pointer-events="none"/><g transform="translate(21.5,220.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="329" height="170" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 330px; height: 171px; overflow: hidden; white-space: nowrap;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse ; font-size: 16px"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left" style="font-size: 16px"><font style="font-size: 16px">Text</font></th><th align="left"><font style="font-size: 16px">Done</font></th></tr><tr style="border: 1px solid #98bf21"><td><font style="font-size: 16px">Clean shower</font></td><td><font style="font-size: 16px">Yes</font></td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td><font style="font-size: 16px">Buy toilet paper</font></td><td><font style="font-size: 16px">No</font></td></tr><tr style="border: 1px solid #98bf21"><td><font style="font-size: 16px">Buy dog food</font></td><td><font style="font-size: 16px">Yes</font></td></tr></tbody></table></div></foreignObject><text x="165" y="91" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 373 287 L 693.9 287.07 Q 703.9 287.07 710.1 279.22 L 861.02 88.35" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 867.23 80.51 L 864.95 91.45 L 857.1 85.25 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><path d="M 373 287 L 844.53 287" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 854.53 287 L 844.53 292 L 844.53 282 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><path d="M 373 287 L 693.9 287.07 Q 703.9 287.07 709.51 295.35 L 831.88 476.02" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 837.49 484.3 L 827.74 478.82 L 836.02 473.21 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><g transform="translate(1057.5,20.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="91" height="110" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 24px; font-family: Helvetica; color: rgb(0, 190, 242); line-height: 1.2; vertical-align: top; white-space: nowrap; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">MySQL<br style="font-size: 24px" />Oracle<br style="font-size: 24px" />MS SQL<br style="font-size: 24px" /><br style="font-size: 24px" /></div></div></foreignObject><text x="46" y="67" fill="#00BEF2" text-anchor="middle" font-size="24px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><g transform="translate(1074.5,251.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="57" height="82" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 24px; font-family: Helvetica; color: rgb(0, 190, 242); line-height: 1.2; vertical-align: top; white-space: nowrap; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">.json<br style="font-size: 24px" />.xml<br style="font-size: 24px" />.yaml<br style="font-size: 24px" /></div></div></foreignObject><text x="29" y="53" fill="#00BEF2" text-anchor="middle" font-size="24px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><g transform="translate(1050.5,465.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="109" height="54" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 24px; font-family: Helvetica; color: rgb(0, 190, 242); line-height: 1.2; vertical-align: top; white-space: nowrap; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">REST API<br style="font-size: 24px" />SOAP<br style="font-size: 24px" /></div></div></foreignObject><text x="55" y="39" fill="#00BEF2" text-anchor="middle" font-size="24px" font-family="Helvetica">[Not supported by viewer]</text></switch></g></g></svg>

---
 


## Database
* **Persistent** data storage
* **Store**, **organize**, and **process information**
  * Query, sort, transform
* Can be **searched**, **referenced**, **compared**, **changed** or otherwise manipulated
* **Database management system (DBMS)**
  * System specifically designed to hold databases

---

## Database Types
* *Relational (SQL)* databases 
    * (examples: MySQL, PostgresSQL, MS SQL, Oracle, ...)
    * Each table has firm structure
    * Relations validation

* *NoSQL* databases
    * (examples: MongoDB, Cassandra, ...)
    * No enforced structure
    * Faster

---

## Relational Database components
* *Schema* - collection of one or more tables
* *Table* - contains multiple columns (similar to columns in a spreadsheet)
* *Column* - contains one of several types of data
* *Row* - **data** in a table is listed in rows (like rows of data in a spreadsheet)

---

## Database persistence

<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" width="758px" viewBox="-0.5 -0.5 758 181" content="&lt;mxfile modified=&quot;2019-02-20T19:15:55.027Z&quot; host=&quot;www.draw.io&quot; agent=&quot;Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.109 Safari/537.36&quot; etag=&quot;h7CU5xadLbQvu28SCr00&quot; version=&quot;10.2.5&quot; type=&quot;onedrive&quot;&gt;&lt;diagram id=&quot;VzwX6c1LZ7_3RVeKrXSE&quot; name=&quot;PersistenceOverview&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;jTaEXDrFFR1zGWIXkIXQ&quot; name=&quot;PersistenceDatabaseSQL&quot;&gt;7VptU9s4EP41+XIzZPwSO8lH8kKvVzhoA3PXT4xiKbYG2fLJCjH8+kq2/C5IQvC0xzQZJtZqtdrdZyXtWgzseZh+YiAOrihEZGAZMB3Yi4Flmabhih9JecopznSSE3yGoWKqCCv8jBTRUNQthihpMHJKCcdxk+jRKEIeb9AAY3TXZNtQ0pw1Bj7qEFYeIF3qPxjyIKdOrHFF/xNhPyhmNt1p3hOCgllZkgQA0l2NZC8H9pxRyvOnMJ0jIp1X+CVMwTdG3C84vZw/n98tY/Y4O8uFXRwzpDSBoYi/WfSD+1d8P791vt6FyzF9Xjj3wZczKxf9CMhW+UvZyp8KBz4ixrHw5yVYI3JDE8wxjUTXmnJOw4E9C3hIRNsUjwXvOcG+5OE0FlSgWp5QHzFBSDijD2hOCRWtRUQjMdVsgwkpSAPLNozZ8sKSzAGIpSph6ssIHYLnLUNDCDhYg0QOPNA7yotSRZTWYkN56xOiIeLsSbCo3tHYyYeoyLcmqr2r4shVsRHUQmiiaEBFrl9KrtARDwqgI8Cy94NVxqghHANBEiCoGjWUtO4nLXhLsPbifyjoLRzDxANomPXGDCdoCOKYCDm5+BfDoS+0CyQLsIt2DWxzokHbtPuCe9SB+xalvAM5l8QGvgwl+BmsMwYJfUxxxDPtnNnAWUhwtlwAmW3VZg0rgjb8RUCTGHg48m9lYyGU6w+KqdWAwja7626kQcLqCwhHs+5cIj3FMy9bxpoyiPJIdf/bygNhZlaPDdXLfkOo6zSYPKFLDCAUXm6wjhpcFfQFUQk/F52FVCPnLdyj6cpVPvMoISCW++h5dgirVm1C11e/ucVrKjKBNpFp9VoD78FndBtBOY1cyXIOsZjB2JuOrFKVZucm+7T0VCbEqZyIEgFXxjudrDeW+Yq2gYwHFcYVWxbnnUH56soHijiRY0+QtpDb6mvSJJEd6smTnAALypwgEGWZDN0hVlcEvjzou8jeXuM8yo6XIgKBjQXtdwK9VHG2fcrSTUwQz3aq+GCr/6bvZ/R7GgOpn2XBFPYJnyTqFrqk51teQd97GDWTDWGxZ8hv94RX696eUXFSbEiWxUgWeaDJiCkzmb6OnXErA5hqMgBdvjft69wZ78/3UATPZZEk8zFCvYd61mc2gUAp5v/Wnr9Ldw4d1VqkyrtZ46nWuEEMC3uy483QAVqmZkKZiwywGvBFzXV8vpDQLfPQ/nQYwUYB2IW3hp+jga+gMURE7vnYLBt1mKoZbmRWVUVPKafIWtp5YW6PGlWv01qC2mWHbTlNQRwwH/GOoCzESrMPirrHxVf369ndVRKu8DiI7xxy/1lbZfzOdj5ctlMM2tAs+LxyPVeMYmXLT3fs50XtQMgFdM+J09KnU9RrJXK/noKt3PBgBX9C1nGKmeYBNr6SubS2nQNXZh+GvJg3H2zViVnWUf56i4WcbQ+JyP9T8n+KO6y3+OJXjNzXKqC1LiA/TERvAEn6D+mfH6r2xwrVbn37scP0XTfePst2ZcDby3ZpmroeNN2B5oKgr7reaVVmZaFfKwwtd6x5tT96h8peW2NpXu1fL65XcqvOcToSH80VmiJ1vNx+uR9iCOU0s12AOVrFIKu5dwzEexGUbV2E9HZFY9nD1pWcrXlHY2mK/N6Q7N4NrJaXy/mtoP0h/i6+XV+JH4Xub1Q1qLZfnOiuWS1DszzfgKloVvf1+QuT6r8e7OUP&lt;/diagram&gt;&lt;diagram id=&quot;Kvzrk7gUgR3qZM4joVvP&quot; name=&quot;PersistenceLoadSQL&quot;&gt;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&lt;/diagram&gt;&lt;/mxfile&gt;" onclick="(function(svg){var src=window.event.target||window.event.srcElement;while (src!=null&amp;&amp;src.nodeName.toLowerCase()!='a'){src=src.parentNode;}if(src==null){if(svg.wnd!=null&amp;&amp;!svg.wnd.closed){svg.wnd.focus();}else{var r=function(evt){if(evt.data=='ready'&amp;&amp;evt.source==svg.wnd){svg.wnd.postMessage(decodeURIComponent(svg.getAttribute('content')),'*');window.removeEventListener('message',r);}};window.addEventListener('message',r);svg.wnd=window.open('https://www.draw.io/?client=1&amp;lightbox=1&amp;edit=_blank');}}})(this);" style="cursor:pointer;max-width:100%;max-height:181px;"><defs/><g><path d="M 475 126.62 C 475 131.25 461.57 135 445 135 C 428.43 135 415 131.25 415 126.62 L 415 63.38 C 415 58.75 428.43 55 445 55 C 461.57 55 475 58.75 475 63.38 Z M 468.47 65.44 C 468.47 62.26 458.24 59.69 445.61 59.69 C 432.99 59.69 422.76 62.26 422.76 65.44 C 422.76 67.49 427.11 69.39 434.18 70.42 C 441.26 71.44 449.97 71.44 457.04 70.42 C 464.11 69.39 468.47 67.49 468.47 65.44 Z M 437.45 112.66 C 441.87 110.74 444.72 106.48 444.72 101.77 C 444.72 97.07 441.87 92.81 437.45 90.89 L 425.2 90.89 L 425.2 112.66 Z M 463.57 112.66 C 465.91 111.66 467.39 109.32 467.3 106.77 C 467.21 104.22 465.56 101.99 463.16 101.16 C 464.71 99.7 465.4 97.54 464.98 95.46 C 464.57 93.37 463.11 91.64 461.12 90.89 L 449.69 90.89 L 449.69 112.66 Z M 428.06 93.77 L 437.04 93.77 C 440 95.33 441.86 98.41 441.86 101.77 C 441.86 105.14 440 108.22 437.04 109.78 L 428.06 109.78 Z M 452.55 93.77 L 460.31 93.77 C 461.33 94.45 461.95 95.61 461.95 96.85 C 461.95 98.09 461.33 99.24 460.31 99.93 L 452.55 99.93 Z M 452.55 103.62 L 460.71 103.62 C 462.52 103.4 464.16 104.68 464.39 106.5 C 464.61 108.31 463.33 109.97 461.53 110.19 L 452.55 110.19 Z Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 127.29 86.04 C 127.29 90.63 126.25 94.34 124.15 97.08 C 122.05 99.81 119.22 101.18 115.71 101.18 C 112.39 101.18 109.83 99.67 108.1 96.59 L 108.01 96.59 L 108.01 113.05 L 103.95 113.05 L 103.95 73.24 L 108.01 73.24 L 108.01 78.02 L 108.1 78.02 C 110.11 74.41 113.02 72.55 116.9 72.55 C 120.09 72.55 122.6 73.77 124.51 76.17 C 126.38 78.61 127.29 81.88 127.29 86.04 Z M 123.15 85.99 C 123.15 83.06 122.51 80.71 121.19 78.95 C 119.91 77.19 118.13 76.31 115.85 76.31 C 113.53 76.31 111.61 77.19 110.15 78.9 C 108.69 80.66 107.96 82.86 107.96 85.55 L 107.96 89.36 C 107.96 91.65 108.65 93.56 110.06 95.12 C 111.47 96.69 113.21 97.42 115.26 97.42 C 117.72 97.42 119.64 96.39 121.05 94.39 C 122.46 92.39 123.15 89.55 123.15 85.99 Z M 97.61 86.04 C 97.61 90.63 96.57 94.34 94.47 97.08 C 92.37 99.81 89.54 101.18 86.03 101.18 C 82.71 101.18 80.15 99.67 78.42 96.59 L 78.33 96.59 L 78.33 113.05 L 74.27 113.05 L 74.27 73.24 L 78.33 73.24 L 78.33 78.02 L 78.42 78.02 C 80.43 74.41 83.34 72.55 87.22 72.55 C 90.41 72.55 92.92 73.77 94.83 76.17 C 96.66 78.61 97.61 81.88 97.61 86.04 Z M 93.42 85.99 C 93.42 83.06 92.78 80.71 91.46 78.95 C 90.18 77.19 88.4 76.31 86.12 76.31 C 83.8 76.31 81.88 77.19 80.43 78.9 C 78.97 80.66 78.24 82.86 78.24 85.55 L 78.24 89.36 C 78.24 91.65 78.92 93.56 80.33 95.12 C 81.75 96.69 83.48 97.42 85.53 97.42 C 87.99 97.42 89.91 96.39 91.32 94.39 C 92.74 92.39 93.42 89.55 93.42 85.99 Z M 66.52 100.5 L 62.46 100.5 L 62.46 96.25 L 62.37 96.25 C 60.59 99.52 57.99 101.18 54.53 101.18 C 52.07 101.18 50.11 100.45 48.65 99.03 C 47.19 97.61 46.46 95.66 46.46 93.27 C 46.46 88.18 49.24 85.2 54.85 84.37 L 62.46 83.25 C 62.46 78.66 60.73 76.31 57.22 76.31 C 54.16 76.31 51.38 77.44 48.92 79.64 L 48.92 75.14 C 49.65 74.55 50.93 73.97 52.75 73.38 C 54.57 72.84 56.17 72.55 57.58 72.55 C 63.56 72.55 66.57 75.97 66.57 82.76 L 66.57 100.5 Z M 62.46 86.72 L 56.31 87.65 C 54.21 87.99 52.75 88.53 51.88 89.26 C 51.02 89.99 50.61 91.21 50.61 92.92 C 50.61 94.29 51.06 95.37 51.98 96.2 C 52.89 97.03 54.07 97.42 55.49 97.42 C 57.49 97.42 59.18 96.64 60.5 95.12 C 61.82 93.61 62.46 91.7 62.46 89.41 L 62.46 86.72 Z M 0 30 L 0 160 L 180 160 L 180 30 L 0 30 L 0 30 Z M 171.02 149.55 L 6.66 149.55 L 6.66 57.26 L 171.02 57.26 L 171.02 149.55 Z" fill="#00bef2" stroke="none" pointer-events="none"/><g transform="translate(33.5,87.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="22" height="12" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; white-space: nowrap;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">Text</div></div></foreignObject><text x="11" y="12" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">Text</text></switch></g><rect x="10" y="60" width="160" height="90" fill="#ffffff" stroke="#c0c0c0" pointer-events="none"/><g transform="translate(10.5,60.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="158" height="88" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 159px; height: 89px; overflow: hidden; white-space: nowrap;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left">Text</th><th align="left">Done</th></tr><tr style="border: 1px solid #98bf21"><td>Clean shower</td><td>Yes</td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td>Buy toilet paper</td><td>No</td></tr><tr style="border: 1px solid #98bf21"><td>Buy dog food</td><td>Yes</td></tr></tbody></table></div></foreignObject><text x="79" y="50" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 180 95 L 400.53 95" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 410.53 95 L 400.53 100 L 400.53 90 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><rect x="490" y="40" width="267" height="140" fill="#ffffff" stroke="#000000" pointer-events="none"/><g transform="translate(490.5,40.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="265" height="138" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 16px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 266px; height: 139px; overflow: hidden; white-space: nowrap; text-align: center;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left"><font color="#000000">ID</font></th><th align="left"><font color="#000000">Text</font></th><th align="left"><font color="#000000">Done</font></th></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">1</font></td><td><table><tbody><tr><td><font color="#000000">Clean shower</font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td><font color="#000000">2</font></td><td><table><tbody><tr><td><font color="#000000">Buy toilet paper<br /></font></td></tr></tbody></table></td><td><font color="#000000">false</font></td></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">3</font></td><td><table><tbody><tr><td><font color="#000000">Buy dog food<br /></font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr></tbody></table></div></foreignObject><text x="133" y="77" fill="#000000" text-anchor="middle" font-size="16px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><g transform="translate(575.5,11.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="96" height="17" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 16px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 96px; white-space: nowrap; overflow-wrap: normal; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">TODOS table</div></div></foreignObject><text x="48" y="17" fill="#000000" text-anchor="middle" font-size="16px" font-family="Helvetica">TODOS table</text></switch></g><g transform="translate(200.5,66.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="185" height="17" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 16px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 187px; white-space: nowrap; overflow-wrap: normal; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">SELECT * FROM TODOS</div></div></foreignObject><text x="93" y="17" fill="#000000" text-anchor="middle" font-size="16px" font-family="Helvetica">SELECT * FROM TODOS</text></switch></g></g></svg>

--- 

## Database persistence

<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" width="901px" viewBox="-0.5 -0.5 901 561" content="&lt;mxfile modified=&quot;2019-02-23T17:46:37.306Z&quot; host=&quot;www.draw.io&quot; agent=&quot;Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.109 Safari/537.36&quot; etag=&quot;L7IEra0_nmor6uqhkQT7&quot; version=&quot;10.2.6&quot; type=&quot;onedrive&quot;&gt;&lt;diagram id=&quot;VzwX6c1LZ7_3RVeKrXSE&quot; name=&quot;PersistenceOverview&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;jTaEXDrFFR1zGWIXkIXQ&quot; name=&quot;PersistenceDatabaseSQL&quot;&gt;7VptU9s4EP41+XIzZPwSO8lH8kKvVzhoA3PXT4xiKbYG2fLJCjH8+kq2/C5IQvC0xzQZJtZqtdrdZyXtWgzseZh+YiAOrihEZGAZMB3Yi4Flmabhih9JecoprjHJCT7DUDFVhBV+RopoKOoWQ5Q0GDmlhOO4SfRoFCGPN2iAMbprsm0oac4aAx91CCsPkC71Hwx5kFMn1rii/4mwHxQzm+407wlBwawsSQIA6a5GspcDe84o5flTmM4Rkc4r/BKm4Bsj7hecXs6fz++WMXucneXCLo4ZUprAUMTfLPrB/Su+n986X+/C5Zg+L5z74MuZlYt+BGSr/KVs5U+FAx8R41j48xKsEbmhCeaYRqJrTTmn4cCeBTwkom2Kx4L3nGBf8nAaCypQLU+oj5ggJJzRBzSnhIrWIqKRmGq2wYQUpIFlG8ZseWFJ5gDEUpUw9WWEDsHzlqEhBBysQSIHHugd5UWpIkprsaG89QnREHH2JFhU72js5ENU5FsT1d5VceSq2AhqITRRNKAi1y8lV+iIBwXQEWDZ+8EqY9QQjoEgCRBUjRpKWveTFrwlWHvxPxT0Fo5h4gE0zHpjhhM0BHFMhJxc/Ivh0BfaBZIF2EW7BrY50aBt2n3BPerAfYtS3oGcS2IDX4YS/AzWGYOEPqY44pl2zmzgLCQ4Wy6AzLZqs4YVQRv+IqBJDDwc+beysRDK9QfF1GpAYZvddTfSIGH1BYSjWXcukZ7imZctY00ZRHmkuv9t5YEwM6vHhuplvyHUdRpMntAlBhAKLzdYRw2uCvqCqISfi85CqpHzFu7RdOUqn3mUEBDLffQ8O4RVqzah66vf3OI1FZlAm8i0eq2B9+Azuo2gnEauZDmHWMxg7E1HVqlKs3OTfVp6KhPiVE5EiYAr451O1hvLfEXbQMaDCuOKLYvzzqB8deUDRZzIsSdIW8ht9TVpksgO9eRJToAFZU4QiLJMhu4QqysCXx70XWRvr3EeZcdLEYHAxoL2O4FeqjjbPmXpJiaIZztVfLDVf9P3M/o9jYHUz7JgCvuETxJ1C13S8y2voO89jJrJhrDYM+S3e8KrdW/PqDgpNiTLYiSLPNBkxJSZTF/HzriVAUw1GYAu35v2de6M9+d7KILnskiS+Rih3kM96zObQKAU839rz9+lO4eOai1S5d2s8VRr3CCGhT3Z8WboAC1TM6HMRQZYDfii5jo+X0jolnlofzqMYKMA7MJbw8/RwFfQGCIi93xslo06TNUMNzKrqqKnlFNkLe28MLdHjarXaS1B7bLDtpymIA6Yj3hHUBZipdkHRd3j4qv79ezuKglXeBzEdw65/6ytMn5nOx8u2ykGbWgWfF65nitGsbLlpzv286J2IOQCuufEaenTKeq1ErlfT8FWbniwgj8h6zjFTPMAG1/JXFrbzoErsw9DXsybD7bqxCzrKH+9xULOtodE5P8p+T/FHdZbfPErRu5rFdBaF5AfJqI3gCT9h/TPD1X7Y4Vqt7792GH6rhtvn2W7MuDtZbs0TV0Pmu5Ac0HQV13vtCqzstCvFYaWO9a82h+9Q2WvrbE0r/avF9cruVXnOB2Jj+YKTZE6Xm6/3A8xhHKa2S7AHK1ikNXcOwbivQjKti5Ceruisexh60rO1ryjsTRFfm9Idu8GVsvL5fxW0P4Qfxffrq/Ej0L3N6oaVNsvTnTXrJahWZ5vwFQ0q/v6/IVJ9V8P9vIH&lt;/diagram&gt;&lt;diagram id=&quot;Kvzrk7gUgR3qZM4joVvP&quot; name=&quot;PersistenceLoadSQL&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;O7l1IK-q1rLzLcDINpSJ&quot; name=&quot;PersistenceORMTool&quot;&gt;ldHBEoIgEADQr+HYjEqZHU0tD3ny0JkRUgpdB2nUvj4dNGO81Al4LAu7IByU3VmSukiAMoEci3YIh8hxbNtyh2GUXotreRpyyekUtEDKX2xCa9Inp6wxAhWAULw2MYOqYpkyjEgJrRl2A2HeWpOcrSDNiFjrlVNVaPWc/eIx43kx32y7B71Tkjl4qqQpCIX2i3CEcCABlJ6VXcDE2Ly5L23p+2FzT/vL8XGLd9u275ONTnb658inBMkq9WvqYbI8bVgYH4yjNw==&lt;/diagram&gt;&lt;/mxfile&gt;" onclick="(function(svg){var src=window.event.target||window.event.srcElement;while (src!=null&amp;&amp;src.nodeName.toLowerCase()!='a'){src=src.parentNode;}if(src==null){if(svg.wnd!=null&amp;&amp;!svg.wnd.closed){svg.wnd.focus();}else{var r=function(evt){if(evt.data=='ready'&amp;&amp;evt.source==svg.wnd){svg.wnd.postMessage(decodeURIComponent(svg.getAttribute('content')),'*');window.removeEventListener('message',r);}};window.addEventListener('message',r);svg.wnd=window.open('https://www.draw.io/?client=1&amp;lightbox=1&amp;edit=_blank');}}})(this);" style="cursor:pointer;max-width:100%;max-height:561px;"><defs><clipPath id="mx-clip-234-199-132-26-0"><rect x="234" y="199" width="132" height="26"/></clipPath><clipPath id="mx-clip-234-225-132-26-0"><rect x="234" y="225" width="132" height="26"/></clipPath><clipPath id="mx-clip-234-251-132-26-0"><rect x="234" y="251" width="132" height="26"/></clipPath></defs><g><path d="M 768.7 336.84 C 768.7 343.16 752.14 348.29 731.71 348.29 C 711.29 348.29 694.73 343.16 694.73 336.84 L 694.73 250.48 C 694.73 244.15 711.29 239.03 731.71 239.03 C 752.14 239.03 768.7 244.15 768.7 250.48 Z M 760.65 253.28 C 760.65 248.94 748.03 245.43 732.47 245.43 C 716.9 245.43 704.29 248.94 704.29 253.28 C 704.29 256.09 709.66 258.68 718.38 260.08 C 727.1 261.48 737.84 261.48 746.56 260.08 C 755.28 258.68 760.65 256.09 760.65 253.28 Z M 722.4 317.77 C 727.85 315.16 731.37 309.34 731.37 302.91 C 731.37 296.49 727.85 290.66 722.4 288.05 L 707.31 288.05 L 707.31 317.77 Z M 754.61 317.77 C 757.49 316.41 759.32 313.21 759.2 309.73 C 759.09 306.25 757.06 303.2 754.11 302.07 C 756.01 300.08 756.86 297.13 756.35 294.28 C 755.84 291.43 754.04 289.07 751.59 288.05 L 737.5 288.05 L 737.5 317.77 Z M 710.83 291.98 L 721.9 291.98 C 725.55 294.1 727.84 298.32 727.84 302.91 C 727.84 307.51 725.55 311.72 721.9 313.85 L 710.83 313.85 Z M 741.02 291.98 L 750.58 291.98 C 751.85 292.91 752.61 294.49 752.61 296.18 C 752.61 297.87 751.85 299.45 750.58 300.39 L 741.02 300.39 Z M 741.02 305.44 L 751.09 305.44 C 753.31 305.13 755.34 306.88 755.62 309.36 C 755.89 311.84 754.32 314.1 752.09 314.41 L 741.02 314.41 Z Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 156.94 281.41 C 156.94 287.69 155.65 292.76 153.06 296.49 C 150.47 300.23 146.99 302.1 142.66 302.1 C 138.56 302.1 135.41 300.03 133.27 295.83 L 133.16 295.83 L 133.16 318.31 L 128.16 318.31 L 128.16 263.93 L 133.16 263.93 L 133.16 270.47 L 133.27 270.47 C 135.75 265.53 139.35 263 144.12 263 C 148.06 263 151.15 264.67 153.51 267.94 C 155.81 271.27 156.94 275.74 156.94 281.41 Z M 151.82 281.35 C 151.82 277.34 151.04 274.14 149.41 271.74 C 147.83 269.34 145.64 268.14 142.83 268.14 C 139.96 268.14 137.6 269.34 135.8 271.67 C 134.01 274.07 133.11 277.08 133.11 280.75 L 133.11 285.95 C 133.11 289.09 133.95 291.69 135.69 293.83 C 137.43 295.96 139.57 296.96 142.1 296.96 C 145.13 296.96 147.5 295.56 149.24 292.82 C 150.98 290.09 151.82 286.22 151.82 281.35 Z M 120.35 281.41 C 120.35 287.69 119.05 292.76 116.47 296.49 C 113.88 300.23 110.4 302.1 106.07 302.1 C 101.97 302.1 98.82 300.03 96.68 295.83 L 96.57 295.83 L 96.57 318.31 L 91.57 318.31 L 91.57 263.93 L 96.57 263.93 L 96.57 270.47 L 96.68 270.47 C 99.15 265.53 102.75 263 107.53 263 C 111.46 263 114.56 264.67 116.92 267.94 C 119.17 271.27 120.35 275.74 120.35 281.41 Z M 115.17 281.35 C 115.17 277.34 114.39 274.14 112.76 271.74 C 111.18 269.34 108.99 268.14 106.18 268.14 C 103.31 268.14 100.95 269.34 99.15 271.67 C 97.36 274.07 96.46 277.08 96.46 280.75 L 96.46 285.95 C 96.46 289.09 97.3 291.69 99.04 293.83 C 100.78 295.96 102.92 296.96 105.45 296.96 C 108.49 296.96 110.85 295.56 112.59 292.82 C 114.33 290.09 115.17 286.22 115.17 281.35 Z M 82.01 301.17 L 77.01 301.17 L 77.01 295.36 L 76.9 295.36 C 74.7 299.83 71.5 302.1 67.23 302.1 C 64.19 302.1 61.77 301.1 59.98 299.16 C 58.18 297.23 57.28 294.56 57.28 291.29 C 57.28 284.35 60.71 280.28 67.62 279.15 L 77.01 277.61 C 77.01 271.34 74.87 268.14 70.54 268.14 C 66.78 268.14 63.35 269.67 60.31 272.67 L 60.31 266.53 C 61.21 265.73 62.79 264.93 65.04 264.13 C 67.28 263.4 69.25 263 70.99 263 C 78.36 263 82.07 267.67 82.07 276.94 L 82.07 301.17 Z M 77.01 282.35 L 69.42 283.62 C 66.83 284.08 65.04 284.82 63.97 285.82 C 62.9 286.82 62.39 288.49 62.39 290.82 C 62.39 292.69 62.96 294.16 64.08 295.29 C 65.2 296.43 66.67 296.96 68.41 296.96 C 70.88 296.96 72.96 295.89 74.59 293.83 C 76.22 291.76 77.01 289.15 77.01 286.02 L 77.01 282.35 Z M 0 204.88 L 0 382.44 L 221.92 382.44 L 221.92 204.88 L 0 204.88 L 0 204.88 Z M 210.84 368.16 L 8.21 368.16 L 8.21 242.11 L 210.84 242.11 L 210.84 368.16 Z" fill="#00bef2" stroke="none" pointer-events="none"/><g transform="translate(40.5,282.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="22" height="12" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; white-space: nowrap;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">Text</div></div></foreignObject><text x="11" y="12" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">Text</text></switch></g><rect x="12.33" y="245.85" width="197.26" height="122.93" fill="#ffffff" stroke="#c0c0c0" pointer-events="none"/><g transform="translate(12.5,246.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="195" height="121" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 196px; height: 122px; overflow: hidden; white-space: nowrap;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left">Text</th><th align="left">Done</th></tr><tr style="border: 1px solid #98bf21"><td>Clean shower</td><td>Yes</td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td>Buy toilet paper</td><td>No</td></tr><tr style="border: 1px solid #98bf21"><td>Buy dog food</td><td>Yes</td></tr></tbody></table></div></foreignObject><text x="98" y="66" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 236.47 293.99 L 690.41 293.66" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 226.47 294 L 236.47 288.99 L 236.48 298.99 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><rect x="567.12" y="368.78" width="332.88" height="191.22" fill="#ffffff" stroke="#000000" pointer-events="none"/><g transform="translate(567.5,369.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="331" height="189" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 16px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 332px; height: 190px; overflow: hidden; white-space: nowrap; text-align: center;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left"><font color="#000000">ID</font></th><th align="left"><font color="#000000">Text</font></th><th align="left"><font color="#000000">Done</font></th></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">1</font></td><td><table><tbody><tr><td><font color="#000000">Clean shower</font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td><font color="#000000">2</font></td><td><table><tbody><tr><td><font color="#000000">Buy toilet paper<br /></font></td></tr></tbody></table></td><td><font color="#000000">false</font></td></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">3</font></td><td><table><tbody><tr><td><font color="#000000">Buy dog food<br /></font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr></tbody></table></div></foreignObject><text x="165" y="103" fill="#000000" text-anchor="middle" font-size="16px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 230 194 L 230 168 L 370 168 L 370 194" fill="#00bef2" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><path d="M 230 194 L 230 272 L 370 272 L 370 194" fill="none" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><path d="M 230 194 L 370 194" fill="none" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><g fill="#000000" font-family="Helvetica" text-anchor="middle" font-size="15px"><text x="299.5" y="187">Todo</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-199-132-26-0)" font-size="15px"><text x="235.5" y="214.5">+ Id: int</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-225-132-26-0)" font-size="15px"><text x="235.5" y="240.5">+ Text: string</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-251-132-26-0)" font-size="15px"><text x="235.5" y="266.5">+ Done: bool</text></g></g></svg>

---

## Support in .NET

* ADO.NET
    * Connection-based
    * Plain SQL
    * Boilerplate coding

---

## Object Relationship Mapping (ORM)

<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" width="901px" viewBox="-0.5 -0.5 901 561" content="&lt;mxfile modified=&quot;2019-02-23T17:49:37.003Z&quot; host=&quot;www.draw.io&quot; agent=&quot;Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.109 Safari/537.36&quot; etag=&quot;IFeeRGNMZt-YLYmlx6rW&quot; version=&quot;10.2.6&quot; type=&quot;onedrive&quot;&gt;&lt;diagram id=&quot;VzwX6c1LZ7_3RVeKrXSE&quot; name=&quot;PersistenceOverview&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;jTaEXDrFFR1zGWIXkIXQ&quot; name=&quot;PersistenceDatabaseSQL&quot;&gt;7VptU9s4EP41+XIzZPwSO8lH8kKvVzhoA3PXT4xiKbYG2fLJCjH8+kq2/C5IQvC0xzQZJtZqtdrdZyXtWgzseZh+YiAOrihEZGAZMB3Yi4Flmabhih9JecoprjHJCT7DUDFVhBV+RopoKOoWQ5Q0GDmlhOO4SfRoFCGPN2iAMbprsm0oac4aAx91CCsPkC71Hwx5kFMn1rii/4mwHxQzm+407wlBwawsSQIA6a5GspcDe84o5flTmM4Rkc4r/BKm4Bsj7hecXs6fz++WMXucneXCLo4ZUprAUMTfLPrB/Su+n986X+/C5Zg+L5z74MuZlYt+BGSr/KVs5U+FAx8R41j48xKsEbmhCeaYRqJrTTmn4cCeBTwkom2Kx4L3nGBf8nAaCypQLU+oj5ggJJzRBzSnhIrWIqKRmGq2wYQUpIFlG8ZseWFJ5gDEUpUw9WWEDsHzlqEhBBysQSIHHugd5UWpIkprsaG89QnREHH2JFhU72js5ENU5FsT1d5VceSq2AhqITRRNKAi1y8lV+iIBwXQEWDZ+8EqY9QQjoEgCRBUjRpKWveTFrwlWHvxPxT0Fo5h4gE0zHpjhhM0BHFMhJxc/Ivh0BfaBZIF2EW7BrY50aBt2n3BPerAfYtS3oGcS2IDX4YS/AzWGYOEPqY44pl2zmzgLCQ4Wy6AzLZqs4YVQRv+IqBJDDwc+beysRDK9QfF1GpAYZvddTfSIGH1BYSjWXcukZ7imZctY00ZRHmkuv9t5YEwM6vHhuplvyHUdRpMntAlBhAKLzdYRw2uCvqCqISfi85CqpHzFu7RdOUqn3mUEBDLffQ8O4RVqzah66vf3OI1FZlAm8i0eq2B9+Azuo2gnEauZDmHWMxg7E1HVqlKs3OTfVp6KhPiVE5EiYAr451O1hvLfEXbQMaDCuOKLYvzzqB8deUDRZzIsSdIW8ht9TVpksgO9eRJToAFZU4QiLJMhu4QqysCXx70XWRvr3EeZcdLEYHAxoL2O4FeqjjbPmXpJiaIZztVfLDVf9P3M/o9jYHUz7JgCvuETxJ1C13S8y2voO89jJrJhrDYM+S3e8KrdW/PqDgpNiTLYiSLPNBkxJSZTF/HzriVAUw1GYAu35v2de6M9+d7KILnskiS+Rih3kM96zObQKAU839rz9+lO4eOai1S5d2s8VRr3CCGhT3Z8WboAC1TM6HMRQZYDfii5jo+X0jolnlofzqMYKMA7MJbw8/RwFfQGCIi93xslo06TNUMNzKrqqKnlFNkLe28MLdHjarXaS1B7bLDtpymIA6Yj3hHUBZipdkHRd3j4qv79ezuKglXeBzEdw65/6ytMn5nOx8u2ykGbWgWfF65nitGsbLlpzv286J2IOQCuufEaenTKeq1ErlfT8FWbniwgj8h6zjFTPMAG1/JXFrbzoErsw9DXsybD7bqxCzrKH+9xULOtodE5P8p+T/FHdZbfPErRu5rFdBaF5AfJqI3gCT9h/TPD1X7Y4Vqt7792GH6rhtvn2W7MuDtZbs0TV0Pmu5Ac0HQV13vtCqzstCvFYaWO9a82h+9Q2WvrbE0r/avF9cruVXnOB2Jj+YKTZE6Xm6/3A8xhHKa2S7AHK1ikNXcOwbivQjKti5Ceruisexh60rO1ryjsTRFfm9Idu8GVsvL5fxW0P4Qfxffrq/Ej0L3N6oaVNsvTnTXrJahWZ5vwFQ0q/v6/IVJ9V8P9vIH&lt;/diagram&gt;&lt;diagram id=&quot;Kvzrk7gUgR3qZM4joVvP&quot; name=&quot;PersistenceLoadSQL&quot;&gt;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&lt;/diagram&gt;&lt;diagram id=&quot;O7l1IK-q1rLzLcDINpSJ&quot; name=&quot;PersistenceORMTool&quot;&gt;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&lt;/diagram&gt;&lt;/mxfile&gt;" onclick="(function(svg){var src=window.event.target||window.event.srcElement;while (src!=null&amp;&amp;src.nodeName.toLowerCase()!='a'){src=src.parentNode;}if(src==null){if(svg.wnd!=null&amp;&amp;!svg.wnd.closed){svg.wnd.focus();}else{var r=function(evt){if(evt.data=='ready'&amp;&amp;evt.source==svg.wnd){svg.wnd.postMessage(decodeURIComponent(svg.getAttribute('content')),'*');window.removeEventListener('message',r);}};window.addEventListener('message',r);svg.wnd=window.open('https://www.draw.io/?client=1&amp;lightbox=1&amp;edit=_blank');}}})(this);" style="cursor:pointer;max-width:100%;max-height:561px;"><defs><clipPath id="mx-clip-234-199-132-26-0"><rect x="234" y="199" width="132" height="26"/></clipPath><clipPath id="mx-clip-234-225-132-26-0"><rect x="234" y="225" width="132" height="26"/></clipPath><clipPath id="mx-clip-234-251-132-26-0"><rect x="234" y="251" width="132" height="26"/></clipPath></defs><g><path d="M 834.2 336.84 C 834.2 343.16 817.64 348.29 797.21 348.29 C 776.79 348.29 760.23 343.16 760.23 336.84 L 760.23 250.48 C 760.23 244.15 776.79 239.03 797.21 239.03 C 817.64 239.03 834.2 244.15 834.2 250.48 Z M 826.15 253.28 C 826.15 248.94 813.53 245.43 797.97 245.43 C 782.4 245.43 769.79 248.94 769.79 253.28 C 769.79 256.09 775.16 258.68 783.88 260.08 C 792.6 261.48 803.34 261.48 812.06 260.08 C 820.78 258.68 826.15 256.09 826.15 253.28 Z M 787.9 317.77 C 793.35 315.16 796.87 309.34 796.87 302.91 C 796.87 296.49 793.35 290.66 787.9 288.05 L 772.81 288.05 L 772.81 317.77 Z M 820.11 317.77 C 822.99 316.41 824.82 313.21 824.7 309.73 C 824.59 306.25 822.56 303.2 819.61 302.07 C 821.51 300.08 822.36 297.13 821.85 294.28 C 821.34 291.43 819.54 289.07 817.09 288.05 L 803 288.05 L 803 317.77 Z M 776.33 291.98 L 787.4 291.98 C 791.05 294.1 793.34 298.32 793.34 302.91 C 793.34 307.51 791.05 311.72 787.4 313.85 L 776.33 313.85 Z M 806.52 291.98 L 816.08 291.98 C 817.35 292.91 818.11 294.49 818.11 296.18 C 818.11 297.87 817.35 299.45 816.08 300.39 L 806.52 300.39 Z M 806.52 305.44 L 816.59 305.44 C 818.81 305.13 820.84 306.88 821.12 309.36 C 821.39 311.84 819.82 314.1 817.59 314.41 L 806.52 314.41 Z Z" fill="#00bef2" stroke="none" pointer-events="none"/><path d="M 156.94 281.41 C 156.94 287.69 155.65 292.76 153.06 296.49 C 150.47 300.23 146.99 302.1 142.66 302.1 C 138.56 302.1 135.41 300.03 133.27 295.83 L 133.16 295.83 L 133.16 318.31 L 128.16 318.31 L 128.16 263.93 L 133.16 263.93 L 133.16 270.47 L 133.27 270.47 C 135.75 265.53 139.35 263 144.12 263 C 148.06 263 151.15 264.67 153.51 267.94 C 155.81 271.27 156.94 275.74 156.94 281.41 Z M 151.82 281.35 C 151.82 277.34 151.04 274.14 149.41 271.74 C 147.83 269.34 145.64 268.14 142.83 268.14 C 139.96 268.14 137.6 269.34 135.8 271.67 C 134.01 274.07 133.11 277.08 133.11 280.75 L 133.11 285.95 C 133.11 289.09 133.95 291.69 135.69 293.83 C 137.43 295.96 139.57 296.96 142.1 296.96 C 145.13 296.96 147.5 295.56 149.24 292.82 C 150.98 290.09 151.82 286.22 151.82 281.35 Z M 120.35 281.41 C 120.35 287.69 119.05 292.76 116.47 296.49 C 113.88 300.23 110.4 302.1 106.07 302.1 C 101.97 302.1 98.82 300.03 96.68 295.83 L 96.57 295.83 L 96.57 318.31 L 91.57 318.31 L 91.57 263.93 L 96.57 263.93 L 96.57 270.47 L 96.68 270.47 C 99.15 265.53 102.75 263 107.53 263 C 111.46 263 114.56 264.67 116.92 267.94 C 119.17 271.27 120.35 275.74 120.35 281.41 Z M 115.17 281.35 C 115.17 277.34 114.39 274.14 112.76 271.74 C 111.18 269.34 108.99 268.14 106.18 268.14 C 103.31 268.14 100.95 269.34 99.15 271.67 C 97.36 274.07 96.46 277.08 96.46 280.75 L 96.46 285.95 C 96.46 289.09 97.3 291.69 99.04 293.83 C 100.78 295.96 102.92 296.96 105.45 296.96 C 108.49 296.96 110.85 295.56 112.59 292.82 C 114.33 290.09 115.17 286.22 115.17 281.35 Z M 82.01 301.17 L 77.01 301.17 L 77.01 295.36 L 76.9 295.36 C 74.7 299.83 71.5 302.1 67.23 302.1 C 64.19 302.1 61.77 301.1 59.98 299.16 C 58.18 297.23 57.28 294.56 57.28 291.29 C 57.28 284.35 60.71 280.28 67.62 279.15 L 77.01 277.61 C 77.01 271.34 74.87 268.14 70.54 268.14 C 66.78 268.14 63.35 269.67 60.31 272.67 L 60.31 266.53 C 61.21 265.73 62.79 264.93 65.04 264.13 C 67.28 263.4 69.25 263 70.99 263 C 78.36 263 82.07 267.67 82.07 276.94 L 82.07 301.17 Z M 77.01 282.35 L 69.42 283.62 C 66.83 284.08 65.04 284.82 63.97 285.82 C 62.9 286.82 62.39 288.49 62.39 290.82 C 62.39 292.69 62.96 294.16 64.08 295.29 C 65.2 296.43 66.67 296.96 68.41 296.96 C 70.88 296.96 72.96 295.89 74.59 293.83 C 76.22 291.76 77.01 289.15 77.01 286.02 L 77.01 282.35 Z M 0 204.88 L 0 382.44 L 221.92 382.44 L 221.92 204.88 L 0 204.88 L 0 204.88 Z M 210.84 368.16 L 8.21 368.16 L 8.21 242.11 L 210.84 242.11 L 210.84 368.16 Z" fill="#00bef2" stroke="none" pointer-events="none"/><g transform="translate(40.5,282.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="22" height="12" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; white-space: nowrap;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">Text</div></div></foreignObject><text x="11" y="12" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">Text</text></switch></g><rect x="12.33" y="245.85" width="197.26" height="122.93" fill="#ffffff" stroke="#c0c0c0" pointer-events="none"/><g transform="translate(12.5,246.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="195" height="121" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 12px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 196px; height: 122px; overflow: hidden; white-space: nowrap;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left">Text</th><th align="left">Done</th></tr><tr style="border: 1px solid #98bf21"><td>Clean shower</td><td>Yes</td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td>Buy toilet paper</td><td>No</td></tr><tr style="border: 1px solid #98bf21"><td>Buy dog food</td><td>Yes</td></tr></tbody></table></div></foreignObject><text x="98" y="66" fill="#000000" text-anchor="middle" font-size="12px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 236.47 294 L 465.53 294" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 226.47 294 L 236.47 289 L 236.47 299 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><path d="M 475.53 294 L 465.53 299 L 465.53 289 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><rect x="567.12" y="368.78" width="332.88" height="191.22" fill="#ffffff" stroke="#000000" pointer-events="none"/><g transform="translate(567.5,369.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="331" height="189" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 16px; font-family: Helvetica; color: rgb(0, 0, 0); line-height: 1.2; vertical-align: top; width: 332px; height: 190px; overflow: hidden; white-space: nowrap; text-align: center;"><table border="1" width="100%" cellpadding="4" style="width: 100% ; height: 100% ; border-collapse: collapse"><tbody><tr style="background-color: #a7c942 ; color: #ffffff ; border: 1px solid #98bf21"><th align="left"><font color="#000000">ID</font></th><th align="left"><font color="#000000">Text</font></th><th align="left"><font color="#000000">Done</font></th></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">1</font></td><td><table><tbody><tr><td><font color="#000000">Clean shower</font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr><tr style="background-color: #eaf2d3 ; border: 1px solid #98bf21"><td><font color="#000000">2</font></td><td><table><tbody><tr><td><font color="#000000">Buy toilet paper<br /></font></td></tr></tbody></table></td><td><font color="#000000">false</font></td></tr><tr style="border: 1px solid #98bf21"><td><font color="#000000">3</font></td><td><table><tbody><tr><td><font color="#000000">Buy dog food<br /></font></td></tr></tbody></table></td><td><font color="#000000">true</font></td></tr></tbody></table></div></foreignObject><text x="165" y="103" fill="#000000" text-anchor="middle" font-size="16px" font-family="Helvetica">[Not supported by viewer]</text></switch></g><path d="M 230 194 L 230 168 L 370 168 L 370 194" fill="#00bef2" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><path d="M 230 194 L 230 272 L 370 272 L 370 194" fill="none" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><path d="M 230 194 L 370 194" fill="none" stroke="#00bef2" stroke-miterlimit="10" pointer-events="none"/><g fill="#000000" font-family="Helvetica" text-anchor="middle" font-size="15px"><text x="299.5" y="187">Todo</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-199-132-26-0)" font-size="15px"><text x="235.5" y="214.5">+ Id: int</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-225-132-26-0)" font-size="15px"><text x="235.5" y="240.5">+ Text: string</text></g><g fill="#000000" font-family="Helvetica" clip-path="url(#mx-clip-234-251-132-26-0)" font-size="15px"><text x="235.5" y="266.5">+ Done: bool</text></g><rect x="480" y="261" width="70" height="66" rx="15.18" ry="15.18" fill="#00bef2" stroke="#00bef2" pointer-events="none"/><g transform="translate(488.5,281.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="52" height="24" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 22px; font-family: Helvetica; color: rgb(255, 255, 255); line-height: 1.2; vertical-align: top; width: 52px; white-space: nowrap; overflow-wrap: normal; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">ORM</div></div></foreignObject><text x="26" y="23" fill="#FFFFFF" text-anchor="middle" font-size="22px" font-family="Helvetica">ORM</text></switch></g><path d="M 564.47 294 L 745.53 294" fill="none" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12 12" pointer-events="none"/><path d="M 554.47 294 L 564.47 289 L 564.47 299 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><path d="M 755.53 294 L 745.53 299 L 745.53 289 Z" fill="#00bef2" stroke="#00bef2" stroke-width="4" stroke-miterlimit="10" pointer-events="none"/><g transform="translate(511.5,234.5)"><switch><foreignObject style="overflow:visible;" pointer-events="all" width="240" height="23" requiredFeatures="http://www.w3.org/TR/SVG11/feature#Extensibility"><div xmlns="http://www.w3.org/1999/xhtml" style="display: inline-block; font-size: 21px; font-family: &quot;Lucida Console&quot;; color: rgb(0, 190, 242); line-height: 1.2; vertical-align: top; width: 242px; white-space: nowrap; overflow-wrap: normal; text-align: center;"><div xmlns="http://www.w3.org/1999/xhtml" style="display:inline-block;text-align:inherit;text-decoration:inherit;">SELECT * FROM TODOS</div></div></foreignObject><text x="120" y="22" fill="#00BEF2" text-anchor="middle" font-size="21px" font-family="Lucida Console">SELECT * FROM TODOS</text></switch></g></g></svg>

---

@snap[north span-100]
## ORM - Pros and Cons
@snapend

@snap[west  span-50]
@ul[](false)
- *Abstract*
- *Portable*
- *No need of SQL knowledge*
- *Cache management*
@ulend
@snapend

@snap[east span-50]
@ul[](false)
- *Slow*
- *Complex queries take time*
- *Limitations* - sometimes its harder to write complex queries
@ulend
@snapend

---

## ORM frameworks

* **Entity Framework** (used in this course)
* **NHibernate** (based on Java Hibernate)
* **Dapper**
* ⋮
* [NuGetMustHaves.com - Top ORM Packages](https://nugetmusthaves.com/Category/ORM)

---

## Entity Framework versions

**Entity Framework**
* Latest version 6
* "Old framework"
* Works only on .NET Framework

**Entity Framework Core**
* open-source
* Current version 2.2
* Works on .NET Standard (supports .NET core -->  multplatform)
* Used in this course

---

## EF Approaches

* **Entity Framework Database First**
  * Creating Entity Data Model from your existing database
* **Entity Framework Code First**
  * *Used in this course*
  * Create the database based on your domain classes and configuration
  * Coding in C# or VB.NET and then EF will create the database from code

--- 

## Data Providers
* Provider model to access many different databases
* NuGet packages which you need to install

| Database | NuGet Package |
|:-:|:- |
| SQL Server | [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) |
| MySQL | [MySql.Data.EntityFrameworkCore](https://www.nuget.org/packages/MySql.Data.EntityFrameworkCore) |
| PostgreSQL | [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) |
| SQLite | [Microsoft.EntityFrameworkCore.SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SQLite) |
| SQL Compact | [EntityFrameworkCore.SqlServerCompact40](https://www.nuget.org/packages/EntityFrameworkCore.SqlServerCompact40) |
| In-memory | [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory) |

---


## Parts of EF Core

* Entities
* DbContext

---

## Entities in EF

* `class` in the domain of your application

```C#
public class Student
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte[]  Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
    public ICollection<Lecture> Lectures { get; set; }
}
```
---

## Entity Properties
* Entity can include **two types of properties**
  * **Scalar Property**
    * Primitive type properties
    * Stores the actual data
    * Maps to a **single column** in the database table
  * **Navigation Property**
    * **Represents a relationship** to another entity
    * Two types
      * *Reference Navigation Property*
        * Includes a property of entity type
        * Represents multiplicity of one (1)
      * *Collection Navigation Property**
        * Includes a property of collection type
        * Represents multiplicity of many (*)

---

### Entity states
* EF API maintains the state of each entity during an its lifetime
* **Each entity has a state** based on the operation performed on it via the `DbContext`
* Represented by an enum [`Microsoft.EntityFrameworkCore.EntityState`](https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.entitystate) (in EF Core)
* Tracking can be requested through `Entry()` method on `DbSet<>`
* Enum values
  1. *Added*
  2. *Modified*
  3. *Deleted*
  4. *Unchanged*
  5. *Detached*

---

## DbContext

* Integral part of Entity Framework
* Instance representing a session with the database
* Used for following tasks:
  1. Manage database connection
  2. Configure model & relationship
  3. Querying database
  4. Saving data to the database
  5. Configure change tracking
  6. Caching
  7. Transaction management

---

## DbContext - example

```C#
public class TodosDbContext : DbContext
{
    public TodosDbContext()
    {
    }
    //Setups provider and other options
    public TodosDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Group> Groups { get; set; }
}
```
@[1-14]
@[3-9]
@[11-13]

---

## Usage - InMemory DbContext creation

```C#
public class TestDbContextFactory : IDbContextFactory
{
    public TodosDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodosDbContext>();
        optionsBuilder.UseInMemoryDatabase("TodoDbName");
        return new TodosDbContext(optionsBuilder.Options);
    }
}
```

---

## Usage - Database connected DbContext creation

```C#
public class DefaultDbContextFactory : IDbContextFactory
{
    public TodosDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodosDbContext>();
        optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True");
        return new TodosDbContext(optionsBuilder.Options);
    }
}
```

---

## Usage - saving data
```C#
var person = new Person
{
    FirstName = "Joe",
    LastName = "Doe"
};

using (var dbContext = CreateDbContext())
{
    dbContext.People.Add(person);
    dbContext.SaveChanges();
}
```
@[1-10]
@[6-10]

---

## Usage - updating data

```C#
person.LastName = "Smith";

using (var dbContext = CreateDbContext())
{
    dbContext.People.Update(person);
    dbContext.SaveChanges();
}
```
@[1-6]
@[3-6]

---

## Usage - deleting data
```C#
var person = new Person
{
    Id = 1
};

using (var dbContext = CreateDbContext())
{
    dbContext.People.Remove(person);
    dbContext.SaveChanges();
}
```
@[1-9]
@[5-9]

---
## Usage - relationships
* Just add them as properties
* Additional configuration of relationships can be done in `DbContext.OnModelCreating` method 

```C#
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Todo> AssignedTodos { get; set; }
}
```

---

## Usage - querying data

* Any expresion created with LINQ
* When querying related object need to use `Include` expression

Example:
```C#
dbContext.Todos
    .Include(t => t.AssignedPerson) //Load also data for AssignedPerson
    .First(t => t.Id == todo.Id);
```

---
## RAW SQL Queries
* `DbSet.FromSql()` - method to execute raw SQL queries


```C#
string name = "Bill";
var context = new SchoolDbContext();

var students = context.Students
              .FromSql($"Select * from Students where Name = '{name}'")
              .ToList();
```

---

## Installation

* NuGet packages for
    * framework
    * selected provider
    * tooling

---

## Installation of Entity Framework Core provider

![](https://raw.githubusercontent.com/orlicekm/CsharpCourse/master/Lectures/Lecture04/Assets/img/install-efcore-1.png)

---

## Installation of Entity Framework Core provider

![](https://raw.githubusercontent.com/orlicekm/CsharpCourse/master/Lectures/Lecture04/Assets/img/install-efcore-2.png)

---

## Installation of Entity Framework Core provider

![](https://raw.githubusercontent.com/orlicekm/CsharpCourse/master/Lectures/Lecture04/Assets/img/install-efcore-3.png)

---

## Installation of Entity Framework Core provider

![](https://raw.githubusercontent.com/orlicekm/CsharpCourse/master/Lectures/Lecture04/Assets/img/install-efcore-4.png)

---

## Installation of Entity Framework Core provider

![](https://raw.githubusercontent.com/orlicekm/CsharpCourse/master/Lectures/Lecture04/Assets/img/install-efcore-5.png)

---
## Migration
* Way to **keep the database schema in sync** with the EF Core model by preserving data
* Set of commands for
  * NuGet Package Manager Console (PMC)
  * Dotnet Command Line Interface (CLI)
* Requires `Microsoft.EntityFrameworkCore.Tools` NuGet package to be installed
* You have to implement `IDesignTimeDbContextFactory<TDbContext>` class

![](https://github.com/orlicekm/CsharpCourse/raw/master/Lectures/Lecture04/Assets/img/ef-core-migration.png)

+++
### Migration commands
| PMC Command                    | CLI Command          | Usage                                                             |
|--------------------------------|----------------------|-------------------------------------------------------------------|
| Add-Migration <migration name> | Add <migration name> | Creates a migration by adding a migration snapshot.               |
| Remove-Migration               | Remove               | Removes the last migration snapshot.                              |
| Update-Database                | Update               | Updates the database schema based on the last migration snapshot. |
| Script-Migration               | Script               | Generates a SQL script using all the migration snapshots.         |

---

### RAW SQL Limitations
* SQL queries **must return entities of the same type** as `DbSet<T>` type. e.g. the specified query cannot return the `CourseEntity` entities if `FromSql()` is used after `Students`. Returning ad-hoc types from `FromSql()` method is in the backlog
* The SQL query **must return all the columns** of the table. e.g. `context.Students.FromSql("Select Id, Name from Students).ToList()` will throw an exception
* The SQL query **cannot include JOIN queries** to get related data. Use `Include` method to load related entities after `FromSql()` method.

---

### Persistence Scenarios - Connected Scenario
* Same instance of the context class (derived from DbContext) is used
* Keeps **track of all entities** during its lifetime
* Useful in local database or the database on the same network
* *Pros*
  * Performs fast
  * Track of all entities and automatically sets an appropriate state
* *Cons*
  * The context stays alive, so the connection with the database stays open
  * Utilizes more resource

+++
### Persistence Scenarios - Connected Scenario
![](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture04/Assets/img/persistance-fg1.PNG?raw=true)

+++
### Persistence Scenarios - Disconnected  Scenario
* **Used in this course**
* **Different instances of the context are used** to retrieve and save entities to the database
* Instance of the dbcontext is **disposed after retrieving data** and a new instance is created to save entities to the database
* Complex because an instance of the context does not track entities
* Useful in web applications or applications with a remote database
* *Pros*
  * Utilizes less resources compared to the connected scenario
  * No open connection with the database
* *Cons*
  * Need to set an appropriate state to each entity before saving
  * Performs slower than the connected scenario

+++
### Persistence Scenarios - Disconnected  Scenario
![](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture04/Assets/img/persistance-fg2.PNG?raw=true)


---

## Design patterns used with peristence

@snap[west span-40]
@ul[](false)
- `Repository` pattern
- `UnitOfWork` pattern
@ulend
@snapend

@snap[east span-60]
![](https://miro.medium.com/max/720/1*U7nXUGkfAFqt0SWmmqlL4g.jpeg)
@snapend
---

## `Repository` pattern

@ul[](false)
- storage for one type of entities
- provides basic CRUD operations used for persistence
    - Create
    - Read
    - Update
    - Delete
- abstracts storage selection from Business Logic
- enables mocking of storage in unit tests
- may provide mapping from entities to business models
@ulend

---
## `Repository` pattern - sample implementation

```C#
public interface ITodosRepository
{
    IEnumerable<TodoListModel> GetAll();
    TodoDetailModel GetById(int id);
    void Update(TodoDetailModel todo);
    TodoDetailModel Add(TodoDetailModel todo);
    void Remove(int id);
}
```

---

## `UnitOfWork` pattern

@snap[mid-point]
@ul[](false)
- handles change tracking of entities
- provides transaction scope (ACID rules)
- *not required in this course*
@ulend
@snapend

@snap[south]
![](https://2s7gjr373w3x22jf92z99mgm5w-wpengine.netdna-ssl.com/wp-content/uploads/2018/06/acid.png)    
@snapend

---

## `UnitOfWork` pattern

```C#
public interface IUnitOfWork
{
    void Rollback();
    void Commit();
}
```

---

```C#
public class BankingService : IBankingService
{
    public void MakeTransaction(Account accountFrom, Account accountTo, double ammount) 
    {
        var unitOfWork = new UnitOfWork();
        try 
        {
            accountFrom.Withdraw(ammount);
            accountTo.Insert(ammount);
            unitOfWork.Commit();        
        }
        catch
        {
            unitOfWowk.Rollback();
        }
    }
}
```

---

## DEMO - Entity Framework Example

- Entities
- DbContext
- Entity configuration
- Example usage
- Migrations

