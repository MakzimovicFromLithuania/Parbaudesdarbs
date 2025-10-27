# 📘 NM_KontaktGramata

## 🧭 Kas tas ir
**NM_KontaktGramata** ir vienkārša C# Windows Forms programma, kas ļauj saglabāt un pārvaldīt kontaktus datorā.  
Tā parāda, kā izmantot **OOP principus** un **datu saglabāšanu JSON failā**.

---

## 💡 Ko var darīt programmā
- Pievienot jaunu kontaktu (vārds, telefons, e-pasts)
- Rediģēt vai dzēst kontaktus
- Meklēt kontaktus pēc vārda, telefona vai e-pasta
- Dati tiek automātiski saglabāti **failā `contacts.json`**

---

## 🪟 Programmas logi
### 🏠 Galvenais logs (Form1)
- Parāda visu kontaktu sarakstu (DataGridView)
- Augšā ir meklēšanas lauks (`txtSearch`)
- Apakšā ir pogas:
  - **Pievienot** (`btnAdd`)
  - **Labot** (`btnEdit`)
  - **Dzēst** (`btnDelete`)

### 📝 Kontaktformas logs (ContactForm)
- Teksta lauki:
  - `txtName` – vārds
  - `txtPhone` – telefons
  - `txtEmail` – e-pasts
- Pogas:
  - **Saglabāt** (`btnOk`)
  - **Atcelt** (`btnCancel`)

---

## 💾 Kur saglabājas dati
Programma automātiski izveido failu **`contacts.json`** un glabā visus kontaktus tur.

Ja palaiž no Visual Studio, fails parasti ir šeit: projekts\bin\Debug\net8.0-windows\contacts.json

## ⚙️ Kā strādā
1. Palaid programmu (F5)
2. Ja faila `contacts.json` vēl nav – tas tiek izveidots
3. Pievieno vai rediģē kontaktus
4. Dati automātiski saglabājas
5. Kad palaid nākamreiz – visi kontakti atkal parādās

---

## 🧠 Tehniskā informācija
- Valoda: **C#**
- Platforma: **.NET Windows Forms**
- Failu formāts: **JSON**
- Namespace: **NM_KontaktGramata**

---

## 🔧 Svarīgās klases
| Klase | Apraksts |
|-------|-----------|
| `Contact` | Glabā kontaktinformāciju un pārbauda, vai dati ir pareizi |
| `ContactRepository` | Saglabā un ielādē kontaktus no faila |
| `Form1` | Galvenā programma ar sarakstu un pogām |
| `ContactForm` | Dialogs kontaktu pievienošanai vai labošanai |

---

## 🧩 OOP un SOLID principi
- **SRP:** katra klase dara tikai vienu darbu (UI, dati, failu saglabāšana)
- **DIP:** UI nezin, kā tieši dati tiek glabāti – tikai izmanto repository
- **OCP:** var viegli pievienot jaunas iespējas (piem., CSV eksportu)

---

## 🧪 Kā pārbaudīt
1. Palaid programmu  
2. Pievieno kontaktu  
3. Pārbaudi meklēšanu  
4. Aizver un atver programmu vēlreiz — dati saglabāti

---

## 👤 Autors
- **Vārds:** *Nikita Maksimovic*  
- **Projekts:** NM_KontaktGramata  
- **Mērķis:** Mācību darbs – C# Windows Forms un OOP praktiska piemērošana
