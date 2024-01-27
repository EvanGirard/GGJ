using System.Collections.Generic;
using UnityEngine;

public class MsgData : MonoBehaviour
{
    #region Attributes

    private static readonly List<string> Sentences = new List<string>
    {
        "Que disent deux fesses dans une pirogue ? Dit donc ça commence à ramer du cul là non.",
        "T'es comme le h de Hawai, tu sers à rien",
        "T'es pas le joint le mieux roulé du paquet",
        "T'es pas le joint le plus étanche du tuyau",
        "T'es pas le chevalier le plus vaillant de la table ronde",
        "T'es pas le pingouin qui glisse le plus loin de la banquise",
        "T'es tellement moche que quand tu lances un boomerang il revient pas",
        "T'es le deuxième enfant. Bien sûr que t'es l'enfant de secours !",
        "T'as un corps de dieu, dommage que ce soit celui de bouddha",
        "Tu es tellement gros quand tu montes dans l'ascenseur qu'il ne peut que descendre.",
        "Tu es tellement gros que tu tombes des deux côtés du lit.",
        "T'es aussi utile qu'un hérisson dans une usine à capote",
        "Quelle mamie fait peur aux voleurs ? Mamie Traillette",
        "Que font deux chevaux dans un magasin ? la course",
        "Que faisaient les dinosaures quand ils n'arrivaient pas à se décider ? Des tirageosaures",
        "Pourquoi les imprimantes n'aiment pas l'eau ? car elles n'ont papier",
        "Comment est-ce que les abeilles communiquent entre elles ? Par e-miel",
        "Quel est l'arbre détesté des chômeurs ? Le bouleau",
        "Comment appelle-t-on un combat entre un petit pois et une carotte ? Un bon duel",
        "Qu'est-ce qui est vert et qui se déplace sous l'eau ? Un chou marin",
        "Que dit un informaticien quand il s'ennuie ? Je me fichier",
        "Que dit une noisette lorsqu'elle tombe dans l'eau ? Je me noix",
        "Que dit une mère à son fils en train de jouer pour qu'il vienne manger ? Alt Tab",
        "C'est l'histoire d'un pingouin qui respire par les fesses, un jour il s'assoit et il meurt.",
        "C'est l'histoire d'une feuille qui tombe à l'eau et elle hurle 'j'ai papier'.",
        "Qu'est ce qu'un canif ? Un petit fien",
        "Qu'est ce qu'une douche sans eau ? Une duche",
        "Qu'est-ce qu'un hamster dans l'espace ? un hamstéroïde",
        "Comment appelle-t-on deux canard qui se disputent ? Un conflit de canards",
        "Que dit le citron quand il braque une banque ? Pas un zeste",
        "Comment appelle-t-on une manifestation d'aveugles ? Un festival de cannes",
        "Comment appelle-t-on un chat tout terrain ? Un Cat Cat",
        "T'es tellement con que tu penses que les archipels c'est pour les architrous",
        "T'es tellement con que tu crois qu'il y a de la neige sur une pizza 4 saisons",
        "Quel est l'endroit préféré d'un mec saoul pour s'asseoir ? Un ta-bourré",
        "A quoi sert une hyperbole ? A boire une hypersoupe",
        "Qu'est ce que dit du raisin blanc à du raisin noir ? T'as oublié ta crème solaire",
        "C'est quoi un nez qui fait peur aux oiseaux ? Un nez-pouvantail",
        "Qu'est-ce qu'un homme dans un champ avec une mitraillette ? un céréale killer",
        "Tu sais pourquoi ça sent mauvais dans ta voiture ? Parce que c'est une Dacia Sandéo",
        "Que fait un crocodile quand il rencontre une femelle ? Il Lacoste",
        "C'est l'histoire d'une brioche qui n'allait jamais aux sports d'hiver ? Parce qu'elle ne savait Pasquier",
        "Comment appelle t-on des testicules de dauphin ? Des boules de Flipper.",
        "Comment une mouette partage son gâteau ? Elle fait mouette mouette",
        "Pourquoi Winnie l'Ourson veut absolument se marier ? Pour partir en lune de miel",
        "Quel est le métier du soleil ? Chef de rayons",
        "Comment appelle-t-on un chat qui a mangé un bonbon ? Un chat-mallow",
        "Avec quoi ramasse-t-on les papayes ? Avec la fou-fourche",
        "Comment faire cuire 9 carottes sans eau ? T'en enlève une et les carottes sont cuites",
        "Pourquoi Mickey Mouse ? Parce que Mario Bros"
    };

    private static readonly List<string> BossSentences = new List<string>
    {
        "I.. Am... Atomic !",
        "Vous savez, moi je ne crois pas qu'il y ait de bonne ou de mauvaise situation. Moi, si je devais résumer ma vie " +
        "aujourd'hui avec vous, je dirais que c'est d'abord des rencontres. Des gens qui m'ont tendu la main, peut-être à " +
        "un moment où je ne pouvais pas, où j'étais seul chez moi. Et c'est assez curieux de se dire que les hasards, " +
        "les rencontres forgent une destinée... Parce que quand on a le goût de la chose, quand on a le goût de la chose " +
        "bien faite, le beau geste, parfois on ne trouve pas l'interlocuteur en face je dirais, le miroir qui vous aide à avancer. " +
        "Alors ça n'est pas mon cas, comme je disais là, puisque moi au contraire, j'ai pu ; et je dis merci à la vie, " +
        "je lui dis merci, je chante la vie, je danse la vie... je ne suis qu'amour ! Et finalement, quand des gens me " +
        "disent « Mais comment fais-tu pour avoir cette humanité ? », je leur réponds très simplement que c'est ce goût " +
        "de l'amour, ce goût donc qui m'a poussé aujourd'hui à entreprendre une construction mécanique... mais demain " +
        "qui sait ? Peut-être simplement à me mettre au service de la communauté, à faire le don, le don de soi."
    };

    private static List<int> _index = new List<int>(); //index of the sentences already done

    #endregion


    #region Other Methods

    public static string GetSentence()
    {
        int nb = Random.Range(0, Sentences.Count);
        while (_index.Contains(nb))
        {
            nb = Random.Range(0, Sentences.Count);
        }
        
        _index.Add(nb);
        return Sentences[nb];
    }

    public static string GetBossSentence()
    {
        return BossSentences[1];
    }

    #endregion
}
