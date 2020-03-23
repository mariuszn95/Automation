namespace Automation.PageObject.Pages.Report
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Locators.Report;

    using NUnit.Framework;

    public class ReportsFooterPage : ReportsPage
    {
        private Label LeftFooter => new Label(FooterLocators.LeftFooter);

        private Label CentreFooter => new Label(FooterLocators.CentreFooter);

        private Label RightFooter => new Label(FooterLocators.RightFooter);

        public ReportsPage VerifyFooter(ReportsEntity report, bool isNna = false)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CheckLeftFooter(report.LeftFooter(isNna));

            // this.CheckCentreFooter();
            this.CheckRightFooter(report.RightFooter);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public void CheckLeftFooter(string value)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, value);

            Assert.AreEqual(value, this.LeftFooter.GetText(), $"{this.LeftFooter.GetText()} are equal {value}");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, value);
        }

        private void CheckCentreFooter()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.CentreFooter.GetCssValue("background-image").Equals(
                "url(\"data:image/png;base64,ivborw0kggoaaaansuheugaaagqaaaaocayaaaf/f2/vaaaaaxnsr0iars4c6qaadb9jrefuaaxtwgly1cuw/7gvqockchacmkogakquwwmz9poin6mzuaxmvn1zas8y26gerzeaolagfpqrpi9yduwexejkv5adzv9khwvzzhm8v3yvqsr+99zvzn/2mbpmmtnnrksqojwgrw79m1hpmo75q6wug/lhjn+27whhgxgklcz58ija02niyiqu31e8jgr/ygrruauqh+4penv+ibizbcvif3cslodai4pbdtogqqsbqu0e5udnnqipqt/b3btlmlz2j8bi5ufirmmfuj5xln78zl8yztjaqinu8zal5z1/kfgx73wvvxy0godwn1di0pqvbmsqq1v3hu8ow7kleuism3fhw8xaqtl8iv5fcxyqfgyglbsdhp3ibuj/mqcijektiupqof/cp7lm3tdytn94sow+fsxtr8msxpn46+lgutizrht0clmafrn1sanovbshk3yn17b/htwi4n9crjkefojmlmafzxfkgbkta3nfuftxnjpbuxkbaijtgtkedveyymwqn9oufo9ivom09fzn4mpfibf0ov2vx5hysoxivleq834ousxq6mdqqvai74aiuyzkmtzyu6a93rg3asjafdpu00wv4hzw1atxdpr0ufjejeu5ufshfv0ywhu/4ngv5myq3tf0dhvkfspgb+fjw0haxboadsdpdhmkq8jvfhbtndch1pqrk264dfnyiprt6o5grfendnrv7z6dge6hezuci+v5jxb566yeqynwpxgtj38irlx6pns0tffnybjut7wglykxznw6rrydptlrmw+tkcqrkmnjlxkl4ou/niess2ut0olychgdmk3/hglmxe7pfxhx85xnxdwmfjgwwytli1oyrwzhiszrvfar+v1/8ky0yatkymwa+y2vrblfn8e8mjchinp7/oiywr6tlimik7nkg3efyhe6ilxeposikjhryqffjbhrwasvkxllgl7hwktilfqanfnnyyoc/fzuuuydxs8vfqropunnzsviymsijyr4v1bangxyk01wwyec7t+slfsgt34oll+2pnjyyro8sletjp+9xhw+hyfixbvm0z3fd/4repgphgffgbnxzjuwaimecyc6yutfnnjh80oyu9kp7j8fsxy9q7tgopuleg9vieorqqctpqxvk+gyld27eg/u+h3dziwxsn8vpolkj/mttq1hph9rr1np7y/a6bqer39jlpdvkpdk1ipyopdrme5lyyru3clmf9izpkb6ycwsxuzhh8q91a+pz6yvc7/z8ahvwcum9yjos0bqzbqjxb2ttzqyb7nzdw0igtfqlsf/umfdi1p3ncl5xeuq/vixp6htpsqkyb2niaxtjfm3hkfy1g25pwtfxkneck7d+d+kt7rb3gllvpvpcd8klm8+tqzrjrj79o9i7+nljabwkbtwfw/8iyvxmxr2ryapmshcu3kx5cknzbo/umwro1q0llnc/uxqvjfbgq/tcem5ce1kx1e/xclp6hrllfpr5exsgsi6vrw2ryqxq5dkortnxbhn1yxsmiaujkzwfcabwtukfljvlirkkmv7zmels8wuk749qzk7ie/vftnk04i4at5zwdwmpepns4uvrdtwkmp5zsgk05z9hofjwdkcj6avw74zmdjyritrlo8bboozcf3+k9psm7kqf02wcxd2piwekjkv58btj/2zkh76i1zcupolihozhd+5blh661nybg4jzxg8/rhh64eveburaxh1nl9f5pvpqjxdefidx90h8/jcshbvaxkeie3llxldxqytxwl2ha5atknomtn9l27nj6gmwz2zoet0ern2roky2lvm1/a9u8ylssqe3wivgedzy+2gdo00ysnrets/8g3csy59jev4zpb+3tpqjznlmgbh3l3h7htcebrqurnachlzxshoaty47zkbtvo2icilm9qpimremz7kbi/7l3jjvhetow87bxpmjq2hp6ofd+giyuboqtubhh4mnues6hyhhm2/hcroo1ng4tv/sbnndem96wovvvtfyq7winfrpetgfajjygygh7rvlukxc/fyolzomq88j3n63btrupzvingdd8pisuoo/nlqwq3svvs7fqxxus2o1o/+ofjw39zyagumjkiaesyg0it1dxtw2tcnkfdsga5mrhhmb41qcrbzsef+xpzy+trq0clrhopslbvabf0bhfjpjgdozcrawh+mqa52lnlkhs7mb/gdbvdzelw0hro+/bw7x3xfqt0b4f18++jjifffbjkyol5w21fygeqgl6upvrs93ciykkrarnujcjvfpqiohtwiqeoljqyj4uhhuludse4arauosp2hzl2zrdodsdwzo4yh6lcpa+togpixic1hgwhyhow5gy2ejfvhbmv3dfgerucuiauwvjml1lezh6hfppyr+qzewq+/r4n9comg28lvxqfwdnxh+gbfci5ctmyhm0zigto9lxdeprqg3jze6lwiiufnenlosaeah8ex5+qbpt0we4ijth6lgn+fbhkgxu7qjjcehdrspxqgneua1hfepubhe59genplsx2oaiexpwax07lgyg0fq109yly1vk8zjikj+zuarmoqrirpw4z/wap2kb+x/wumuuq/+zm1a5hp2fjkmvcegwtzddczbv99ey2zahtrc9wgjrhcrxjiareivoiyopwxlnoxkbmq9pia08cowqinnfwn/+kis9q75gzil5vjbyuexlkm7+v3lzssjfofmt+nplpc4zlkmxnaijip/jx+twqij1du1gcwftf0sbfaj3ummf4bwzlnfupkqxqy9z/vyw1ujn/emdoklvrofc523be/+dle+oyklrkoq0xqliqimfsxpiefpzbdx6z5hs893b/3dtmh++zentwma2ws4bj6j3zamgaglxklypbcdnrx4x2xljykvlrpraxczemaqtfpxq6asjtti4smslj+db2kwemcwtlx39ykcyy4yfmt23cgxkdcefnly7cix7kmfhwiq4+j6e0hhry1c4smouonfw2xzewizv/glpcn0s2enpxwfaupwemxddqafjzw4pvvt8kuq5m82usmk2nx0smojnxwegfarf+plgl06eomb1+tj5ejomkvnx6mxx6dygpmudxloe980i7d6gojra31kz5bdfndfvh0mzrzvpmed54ix8w4a4jateawnbump1cqdoz41kyluwbksjrxvcob3m7szf0yaai8vwaknn7iawmh2mkaxqmykgubgz7kkctcc/ez42sagx+pxzcxv0dstkuwntsjogpjhhxpj5z1aqjszn+vut5eddzttemie4ph9oujr0gaokhyxg2xh+e8xzhcoqcm6euks2jdbzr7mdnbzgrdimrpjopgqnw1030bfaki4dhnmcylfzcmnbegiirsbd8whlvullj05bav41mafbr5pzb4prin6cevnrhpbqvrxyzaclrjnfvugjpqhmj+f8bgid2/aq7yjc4wba9ysrm6fz2kz9x9mzs82qtieuucqaebzmglrmrg3bk6cttaryxcnj3t1+f13qqgyxvmhmovv4jwexebajwojanlj0xmegaiusrxheaa8v1vyajzhywg77rhva+ciyazejbvexpzienv+zyg3nofgv7ge146ugwzkhqznkpmtgl6tvzvmwqi7rcfpitwnvsw4/id+ov8nhtvm7fscm5glbc/rq/zq5c4wvkuopqwhwbfa8fxtcmthitjji2gkzi6kgf1uy28ollah8qrsm1zffeyrqrxxewkgjg/gr5p08mzlpi6ivanczhqxgrlcovunvxxcsznrh7q5inllu08ia85ckj98ruye+fj6ekmnvpyyfllcqmqpaei5bxk6w0yr2jja11sruzsshh1s5axbdh0dtupx4inxvu8/sxw2hy3hxndve49e4ppdp6fhymhvnh9sd0x8blvjbxpo7ezh3qmh+m0ft0vkttuzadaq5pqr9d4csj80aqo8orhl9ksnr0j/jqdn3gj0vnnatov6ygtn8z1mly1c+a6tc1f3x2hcd+ty2mria3rslo7psigulnt0zmmj7ztqmoqttowxxvqmkrdydn2zjqmatsn27uhdupalzxt7+z/s7fac1oz6ueaaaaasuvork5cyii=\")"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void CheckRightFooter(string value)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, value);

            Assert.IsTrue(this.RightFooter.GetText().Contains(value), $"{this.RightFooter.GetText()} contains {value}");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, value);
        }
    }
}