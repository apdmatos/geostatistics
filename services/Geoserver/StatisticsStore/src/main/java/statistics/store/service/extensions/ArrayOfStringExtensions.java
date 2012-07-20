package statistics.store.service.extensions;

import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfstring;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class ArrayOfStringExtensions extends ArrayOfstring {

    public ArrayOfStringExtensions() {
        this.string = new ArrayList<String>();
    }

    public ArrayOfStringExtensions(List<String> strs){
        this.string = strs;
    }

    public void add(String str) {
        this.string.add(str);
    }
}
